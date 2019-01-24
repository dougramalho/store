
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISet<Product> _products = new HashSet<Product>();

        public async Task<Product> GetAsync(string name)
        {
            var product = _products.SingleOrDefault(x => x.Name == name);

            return await Task.FromResult(product);
        }

        public async Task<IEnumerable<string>> GetNamesAsync()
         => await Task.FromResult(_products.Select(x => x.Name));

        public async Task AddAsync(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Product product) => await Task.CompletedTask; //Nothing to do now
        
        public async Task RemoveAsync(string name)
        {
            _products.Remove(await GetAsync(name));
        }

    }
}