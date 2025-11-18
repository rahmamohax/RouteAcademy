using E_Commerce.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace E_Commerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //Get : BaseUrl/api/Product
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int  id)
        {
            return new Product() { Id = id, Name = "Test"};
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return new List<Product>();
        }

        [HttpPost]
        public ActionResult<Product> AddProduct(Product product)
        {
            return product;
        }

        [HttpPut]
        public ActionResult<Product> UpdateProduct(Product product)
        {
            return product;
        }

        [HttpDelete]
        public ActionResult<Product> DeleteProduct(Product product)
        {
            return product;
        }
    }
}
