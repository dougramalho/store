using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities = Store.Core.Domain;

namespace Store.Core.Repositories.Product {
    public class ProductRepository : IProductRepository {
        private readonly ISet<Entities.Product> _products = new HashSet<Entities.Product> ();

        public async Task<Entities.Product> GetAsync (string name) {
            var product = _products.SingleOrDefault (x => x.Name == name);

            return await Task.FromResult (product);
        }

        public async Task<IEnumerable<string>> GetNamesAsync () => await Task.FromResult (_products.Select (x => x.Name));

        public async Task AddAsync (Entities.Product product) {
            _products.Add (product);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync (Entities.Product product) => await Task.CompletedTask; //Nothing to do now

        public async Task RemoveAsync (string name) {
            _products.Remove (await GetAsync (name));
        }

        public async Task<IEnumerable<Entities.Product>> GetLatestAsync (int quantity) => await Task.FromResult (_products.OrderByDescending (x => x.PublishedAt).Take (quantity));

        public async Task<IEnumerable<Entities.Product>> GetFeaturedAsync (int quantity) => await Task.FromResult (_products.Where(x => x.Featured).Take (quantity));
    }
}