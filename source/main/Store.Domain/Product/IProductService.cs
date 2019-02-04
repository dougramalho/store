using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Domain.Product
{
    public interface IProductService
    {
        Task<ProductDTO> GetAsync(string name);
        Task<IEnumerable<string>> GetnamesAsync();
        Task AddAsync(string name, decimal price, DateTime publishedAt, bool featured);
        Task RemoveAsync(string name);

        Task<IEnumerable<ProductDTO>> GetLatestAsync(int quantity);
        Task<IEnumerable<ProductDTO>> GetFeaturedAsync(int quantity);
    }
}