
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities = Store.Core.Domain; 

namespace Store.Core.Repositories.Product
{
    public interface IProductRepository
    {
        Task<Entities.Product> GetAsync(string name);
        Task<IEnumerable<string>> GetNamesAsync();
        Task AddAsync(Entities.Product product);
        Task UpdateAsync(Entities.Product product);
        Task RemoveAsync(string name);

        Task<IEnumerable<Entities.Product>> GetLatestAsync(int quantity);
        Task<IEnumerable<Entities.Product>> GetFeaturedAsync(int quantity);
    }
}