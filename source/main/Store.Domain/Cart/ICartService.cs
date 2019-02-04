using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Domain.Product;

namespace Store.Domain.Cart
{
    public interface ICartService
    {
         Task AddAsync (Guid id, string productName);
         Task CreateAsync(Guid id);
         Task<decimal> GetTotalAsync(Guid id);
         Task<IEnumerable<ProductDTO>> GetItemsAsync(Guid id);
    }
}