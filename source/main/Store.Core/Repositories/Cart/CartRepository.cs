using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories.Cart {
    public class CartRepository : ICartRepository {
        private readonly ISet<Domain.Cart> _carts = new HashSet<Domain.Cart> ();

        public async Task AddItem (Guid id, Domain.Product product) {
            var cart = _carts.SingleOrDefault (x => x.Id == id);
            cart.AddProduct (product);

            await Task.CompletedTask;
        }

        public async Task Create (Guid id) {
            Domain.Cart cart = new Domain.Cart(id);
            _carts.Add(cart);

            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Domain.Product>> GetProducts (Guid id) {
            var cart = _carts.SingleOrDefault (x => x.Id == id);

            return await Task.FromResult(cart.Products);
        }

        public async Task<decimal> GetTotal (Guid id) {
            var cart = _carts.SingleOrDefault (x => x.Id == id);

            return await Task.FromResult(cart.Products.Select(x => x.Price).Sum());
        }
    }
}