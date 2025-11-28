using E_Commerce.Presentation.Attributes;
using E_Commerce.Service_Abstraction;
using E_Commerce.Shared;
using E_Commerce.Shared.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Controllers
{
    public class ProductsController  : ApiBaseController 
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [RedisCache]
        public async Task<ActionResult<PaginatedResult<ProductDTO>>> GetAllProducts([FromQuery]ProductQueryParams queryParams)
        {
            var products = await _productService.GetAllProductsAsync(queryParams);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return HandleResult<ProductDTO>(product);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeDTO>>> GetAllTypes()
        {
            var types = await _productService.GetAllTypesAsync();
            return Ok(types);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetAllBrand()
        {
            var brands = await _productService.GetAllBrandsAsync();
            return Ok(brands);
        }
    }
}
