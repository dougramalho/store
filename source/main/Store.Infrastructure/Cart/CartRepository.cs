using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Cart;
using Store.Domain.Product;

namespace Store.Infrastructure.Cart {
    public class CartRepository : ICartRepository {
        private readonly ISet<Domain.Cart.Cart> _carts = new HashSet<Domain.Cart.Cart> ();

        public async Task AddItem (Guid id, Store.Domain.Product.Product product) {
            var cart = _carts.SingleOrDefault (x => x.Id == id);
            cart.AddProduct (product);

            await Task.CompletedTask;
        }

        public async Task Create (Guid id) {
            Domain.Cart.Cart cart = new Domain.Cart.Cart(id);
            _carts.Add(cart);

            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Store.Domain.Product.Product>> GetProducts (Guid id) {
            var cart = _carts.SingleOrDefault (x => x.Id == id);

            return await Task.FromResult(cart.Products);
        }

        public async Task<decimal> GetTotal (Guid id) {
            var cart = _carts.SingleOrDefault (x => x.Id == id);

            return await Task.FromResult(cart.Products.Select(x => x.Price).Sum());
        }
    }
}