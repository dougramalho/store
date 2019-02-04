using System;
using System.Threading.Tasks;

namespace Store.Domain.Product
{
    public static class Extensions
    {
        public static async Task<Product> GetOrFailAsync(this IProductRepository repository, string name)
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