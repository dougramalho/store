using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Product;

namespace Store.Infrastructure.Product {
    public class ProductRepository : IProductRepository {
        private readonly ISet<Store.Domain.Product.Product> _products = new HashSet<Store.Domain.Product.Product> ();

        public async Task<Store.Domain.Product.Product> GetAsync (string name) {
            var product = _products.SingleOrDefault (x => x.Name == name);

            return await Task.FromResult (product);
        }

        public async Task<IEnumerable<string>> GetNamesAsync () => await Task.FromResult (_products.Select (x => x.Name));

        public async Task AddAsync (Store.Domain.Product.Product product) {
            _products.Add (product);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync (Store.Domain.Product.Product product) => await Task.CompletedTask; //Nothing to do now

        public async Task RemoveAsync (string name) {
            _products.Remove (await GetAsync (name));
        }

        public async Task<IEnumerable<Store.Domain.Product.Product>> GetLatestAsync (int quantity) => await Task.FromResult (_products.OrderByDescending (x => x.PublishedAt).Take (quantity));

        public async Task<IEnumerable<Store.Domain.Product.Product>> GetFeaturedAsync (int quantity) => await Task.FromResult (_products.Where(x => x.Featured).Take (quantity));
    }
}