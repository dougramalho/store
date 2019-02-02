using System;
using System.Threading.Tasks;
using Entities = Store.Core.Domain; 
using Store.Core.Repositories.Product;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public static class Extensions
    {
        public static async Task<Entities.Product> GetOrFailAsync(this IProductRepository repository, string name)
        {
            var product = await repository.GetAsync(name);

            if (product == null)
            {
                throw new StoreException("product_not_found", $"Product: {name} was not found.");
            }

            return product;
        }
    }
}