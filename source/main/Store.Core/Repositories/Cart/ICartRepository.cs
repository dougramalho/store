using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities = Store.Core.Domain;

namespace Store.Core.Repositories.Cart
{
    public interface ICartRepository
    {
         Task AddItem(Guid id, Entities.Product product);
         Task Create(Guid id);

         Task<decimal> GetTotal(Guid id);

         Task<IEnumerable<Domain.Product>> GetProducts(Guid id);
    }
}