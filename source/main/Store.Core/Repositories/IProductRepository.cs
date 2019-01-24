
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(string name);
        Task<IEnumerable<string>> GetNamesAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task RemoveAsync(string name);
    }
}