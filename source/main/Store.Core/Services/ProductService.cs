using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Store.Core.Domain;
using Store.Core.DTO;
using Store.Core.Repositories;

namespace Store.Core.Services
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

        public async Task AddAsync(string name, decimal price)
        {
            var product = await _productRepository.GetAsync(name);

            if (product != null)
            {
                throw new StoreException("product_already_exists", $"Product: {name} already exists.");
            }
            
            product = new Product(Guid.NewGuid(), name, price);
            await _productRepository.AddAsync(product);
        }

        public async Task RemoveAsync(string name)
        => await _productRepository.RemoveAsync(name);
    }
}