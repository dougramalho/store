using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.DTO;
using Entities = Store.Core.Domain;

namespace Store.Core.Services.Cart
{
    public interface ICartService
    {
         Task AddAsync(Guid id, Entities.Product product);
         Task CreateAsync(Guid id);
         Task<decimal> GetTotalAsync(Guid id);
         Task<IEnumerable<ProductDTO>> GetItemsAsync(Guid id);
    }
}