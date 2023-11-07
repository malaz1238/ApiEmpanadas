using Empanadas.Data.Entities;
using Empanadas.Services.Interfaces;
using Empanadas.Data.ProductDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empanadas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IProductService _productService;

        public ApiController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_productService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(ProductDto dto)
        {
            var product = new Product()
            {
                ProductId = dto.ProductId,
                Tastes = dto.Tastes,
                Description = dto.Description,
                Price = dto.Price,
            };
            return Ok(_productService.Add(product));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}
