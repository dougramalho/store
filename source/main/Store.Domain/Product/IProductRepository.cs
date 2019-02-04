
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Domain.Product
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(string name);
        Task<IEnumerable<string>> GetNamesAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task RemoveAsync(string name);

        Task<IEnumerable<Product>> GetLatestAsync(int quantity);
        Task<IEnumerable<Product>> GetFeaturedAsync(int quantity);
    }
}