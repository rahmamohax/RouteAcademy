using E_Commerce.Service_Abstraction;
using E_Commerce.Shared.DTOs.BasketDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            this._basketService = basketService;
        }

        [HttpGet]
        public async Task<ActionResult<BasketDto>> GetBasket(string id)
        {
            var basket = await _basketService.GetBasketAsync(id);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrUpdateBasket(BasketDto basket)
        {
            var createdBasket = await _basketService.CreateOrUpdateBasketAsync(basket);
            return Ok(createdBasket);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBasket(string id)
        {
            var isDeleted = await _basketService.DeleteBasketAsync(id);
            return Ok(isDeleted);
        }

    }
}
