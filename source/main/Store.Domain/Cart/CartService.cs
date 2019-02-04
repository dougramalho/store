using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Store.Domain.Product;

namespace Store.Domain.Cart {
    public class CartService : ICartService {
        private readonly ICartRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CartService (ICartRepository repository, IProductRepository productRepository, IMapper mapper) {
            _repository = repository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task AddAsync (Guid id, string productName) {
            var product = await _productRepository.GetAsync(productName);
            await _repository.AddItem(id, product);
        }

        public async Task CreateAsync (Guid id) {
            await _repository.Create(id);
        }

        public async Task<IEnumerable<ProductDTO>> GetItemsAsync (Guid id) {
            var products = await _repository.GetProducts(id);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<decimal> GetTotalAsync (Guid id) {
            return await _repository.GetTotal(id);
        }
    }
}