using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Core.Domain;
using Store.Core.DTO;
using Store.Core.Repositories;

namespace Store.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDTO> GetAsync(string name)
        {
            var product = await _productRepository.GetOrFailAsync(name);

            return new ProductDTO(){
                Name = product.Name,
                Price = product.Price,
                Details = product.Details.Select(x => x.Name).ToList()
            };
        }

        public async Task<IEnumerable<string>> GetnamesAsync()
        => await _productRepository.GetNamesAsync();

        public async Task AddAsync(string name, decimal price)
        {
            var product = await _productRepository.GetAsync(name);

            if (product != null)
            {
                throw new Exception($"Product: {name} already exists.");
            }
            
            product = new Product(Guid.NewGuid(), name, price);
            await _productRepository.AddAsync(product);
        }

        public async Task RemoveAsync(string name)
        => await _productRepository.RemoveAsync(name);
    }
}