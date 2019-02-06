using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Domain.Cart
{
    public interface ICartRepository
    {
         Task AddItem(Guid id, Product product);
         Task Create(Guid id);

         Task<decimal> GetTotal(Guid id);

         Task<IEnumerable<Product>> GetProducts(Guid id);
    }
}