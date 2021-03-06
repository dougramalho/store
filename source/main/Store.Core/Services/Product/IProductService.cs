using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.DTO;

namespace Store.Core.Services.Product
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