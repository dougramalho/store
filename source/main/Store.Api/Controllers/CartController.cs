using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Core.DTO;
using Store.Core.Services.Cart;

namespace Store.Api.Controllers {
    [Route ("api/[controller]")]
    public class CartController : Controller {
        private readonly ICartService _cartService;
        public CartController (ICartService cartService) {
            _cartService = cartService;
        }

        [HttpGet ("{cartId}/items")]
        public async Task<IActionResult> Get (Guid cartId) {
            var products = await _cartService.GetItemsAsync (cartId);
            return Json (products);
        }

        [HttpGet ("{cartId}/total")]
        public async Task<IActionResult> GetTotal (Guid cartId) {
            var total = await _cartService.GetTotalAsync (cartId);
            return Json(total);
        }

        [HttpPost ("{cartId}/add")]
        public async Task<IActionResult> AddItem (Guid cartId, [FromBody] CartProductDTO product) {
            await _cartService.AddAsync(cartId, product.ProductName);
             return Created ($"{cartId}/items", null);
        }

        [HttpPost ("")]
        public async Task<IActionResult> Post () {
            var cartId = Guid.NewGuid();
            await _cartService.CreateAsync(cartId);
            return Created ($"cart/{cartId}", null);
        }
    }
}