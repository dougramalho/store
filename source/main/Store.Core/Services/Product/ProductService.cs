using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities = Store.Core.Domain; 
using Store.Core.DTO;
using Store.Core.Repositories;
using Store.Core.Repositories.Product;
using Store.Core.Domain;

namespace Store.Core.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetAsync(string name)
        {
            var product = await _productRepository.GetOrFailAsync(name);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<string>> GetnamesAsync()
        => await _productRepository.GetNamesAsync();

        public async Task AddAsync(string name, decimal price, DateTime publishedAt, bool featured)
        {
            var product = await _productRepository.GetAsync(name);

            if (product != null)
            {
                throw new StoreException("product_already_exists", $"Product: {name} already exists.");
            }
            
            product = new Entities.Product(Guid.NewGuid(), name, price, publishedAt, featured);
            await _productRepository.AddAsync(product);
        }

        public async Task RemoveAsync(string name)
        => await _productRepository.RemoveAsync(name);

        public async Task<IEnumerable<ProductDTO>> GetLatestAsync(int quantity)
        {
            var products = await _productRepository.GetLatestAsync(quantity);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<IEnumerable<ProductDTO>> GetFeaturedAsync(int quantity)
        {
            var products = await _productRepository.GetFeaturedAsync(quantity);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}