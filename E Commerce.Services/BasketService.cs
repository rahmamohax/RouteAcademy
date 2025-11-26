using AutoMapper;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.BasketModule;
using E_Commerce.Service_Abstraction;
using E_Commerce.Services.Exceptions;
using E_Commerce.Shared.DTOs.BasketDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository basketRepository, IMapper mapper)
        {
            this._basketRepository = basketRepository;
            this._mapper = mapper;
        }
        public async Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basket)
        {
            var customerBasket = _mapper.Map<CustomerBasket>(basket);
            var desiredBasket = await _basketRepository.CreateOrUpdateBasketAsync(customerBasket);

            return _mapper.Map<BasketDto>(desiredBasket);
            }

        public async Task<bool> DeleteBasketAsync(string id) => await _basketRepository.DeleteBasketAsync(id);

        public async Task<BasketDto> GetBasketAsync(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            if (basket is null)
                throw new BasketNotFoundException(id);
            return _mapper.Map<BasketDto>(basket);
        }
    }
}
