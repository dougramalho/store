using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Core.DTO;
using Store.Core.Services;

namespace Store.Api.Controllers
{
    [Route("api/products/{productName}/details")]
    public class ProductDetailsController : Controller
    {
        private readonly IProductDetailService _productDetailService;
        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get(string productName)
        {
            var details = await _productDetailService.GetAsync(productName);

            if(details == null)
                return NoContent();

            return Json(details);
        }

        [HttpPost("{name}")]
        public async Task<IActionResult> Post(string productName, [FromBody]ProductDetailDTO detail)
        {
            await _productDetailService.AddAsync(productName, detail.Name, detail.Value);
            return Created($"products/{productName}/details/", null);
        }

        [HttpDelete("{detailName}")]
        public async Task<IActionResult> Post(string productName, string detailName)
        {
            await _productDetailService.RemoveAsync(productName, detailName);
            return NoContent();
        }
    }
}