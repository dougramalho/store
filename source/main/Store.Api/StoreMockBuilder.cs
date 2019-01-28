using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Store.Core.Domain;
using Store.Core.Repositories;

namespace Store.Api {
    public class StoreMockBuilder : IStoreMockBuilder {
        private readonly IProductRepository _productRepository;
        public StoreMockBuilder (IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        public void Mock () {
            _productRepository.AddAsync(new Product(Guid.NewGuid(), "Product-1", 100.00m));
            _productRepository.AddAsync(new Product(Guid.NewGuid(), "Product-2", 100.00m));
            _productRepository.AddAsync(new Product(Guid.NewGuid(), "Product-3", 100.00m));
            _productRepository.AddAsync(new Product(Guid.NewGuid(), "Product-4", 100.00m));
        }
    }

    public interface IStoreMockBuilder {
        void Mock ();
    }
}