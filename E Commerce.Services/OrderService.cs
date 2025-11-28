using AutoMapper;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.OrderModule;
using E_Commerce.Domain.Entities.ProductModule;
using E_Commerce.Service_Abstraction;
using E_Commerce.Shared.CommonResult;
using E_Commerce.Shared.OrderDtos;

namespace E_Commerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IMapper mapper, IBasketRepository basketRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<OrderToReturnDto>> CreateOrderAsync(OrderDto orderDto, string email)
        {
            var orderAdd = _mapper.Map<OrderAddress>(orderDto.Address);
            var basket = await _basketRepository.GetBasketAsync(orderDto.BasketId);
            if (basket == null) return Error.NotFound("Basket.NotFound");

            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(item.Id);
                if (product == null) return Error.NotFound("Product.NotFound", $"Product with id {item.Id} is not Found");
                orderItems.Add(CreateOrderItem(item, product));
                //orderItems.Add(item.Id);
            }

            var deliveryMethod = await _unitOfWork.GetRepository<DeliveryMethod, int>().GetByIdAsync(orderDto.DeliveryMethodId);
            if (deliveryMethod == null) return Error.NotFound("DeliveryMethod.NotFound");

            var subTotal = orderItems.Sum(x => x.Price * x.Quantity);

            var order = new Order()
            {
                Address = orderAdd,
                DeliveryMethod = deliveryMethod,
                Items = orderItems,
                SubTotal = subTotal,
                UserEmail = email
            };

            await _unitOfWork.GetRepository<Order, Guid>().AddAsync(order);
            int res =await _unitOfWork.SaveChangesAsync();
            if (res == 0) return Error.Failure("Order.Failure");

            return _mapper.Map<OrderToReturnDto>(order);
        }

        private static OrderItem CreateOrderItem(Domain.Entities.BasketModule.BasketItem item, Product product)
        {
            return new OrderItem()
            {
                Product = new ProductItemOrdered()
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    PictureUrl = product.PictureUrl,
                },
                Id = item.Id,
                Price = item.Price,
                Quantity = item.Quantity,
            };
        }
    }
}
