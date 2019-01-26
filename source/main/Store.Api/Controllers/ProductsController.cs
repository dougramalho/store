using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Core.DTO;
using Store.Core.Services;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetnamesAsync();
            return Json(products);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var product = await _productService.GetAsync(name);

            if(product == null)
                return NotFound();

            return Json(product);
        }

        [HttpPost("{productName}")]
        public async Task<IActionResult> Post(string productName, [FromBody]ProductDTO product)
        {
            await _productService.AddAsync(product.Name, product.Price);
            return Created($"products/{productName}", null);
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Post(string name)
        {
            await _productService.RemoveAsync(name);
            return NoContent();
        }
    }
}