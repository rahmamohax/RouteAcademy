using AutoMapper;
using E_Commerce.Domain.Entities.OrderModule;
using E_Commerce.Shared.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<AddressDto, OrderAddress>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(x => x.ProductName, o=> o.MapFrom(s=> s.Product.ProductName))
                .ForMember(x => x.PictureUrl, o=> o.MapFrom<OrderItemPictureUrlResolver>())
                .ReverseMap();

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, opt => opt.MapFrom(src => src.DeliveryMethod.ShortName))
                .ReverseMap();
        }
    }
}
