using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Domain.Cart
{
    public interface ICartRepository
    {
         Task AddItem(Guid id, Store.Domain.Product.Product product);
         Task Create(Guid id);

         Task<decimal> GetTotal(Guid id);

         Task<IEnumerable<Store.Domain.Product.Product>> GetProducts(Guid id);
    }
}