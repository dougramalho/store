using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Store.Core.Domain;
using Store.Core.Repositories;

namespace Store.Api {
    public class StoreMockBuilder : IStoreMockBuilder {
        private readonly IProductRepository _productRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly ICategoryRepository _categoryRepository;
        public StoreMockBuilder (IProductRepository productRepository,
            IBlogRepository blogRepository,
            ICategoryRepository categoryRepository) {

            _productRepository = productRepository;
            _blogRepository = blogRepository;
            _categoryRepository = categoryRepository;
        }

        public void Mock () {
            MockProducts ();
            MockPosts ();
            MockCategories ();
        }

        private void MockProducts () {
            _productRepository.AddAsync (new Product (Guid.NewGuid (), "Product-1", 100.00m));
            _productRepository.AddAsync (new Product (Guid.NewGuid (), "Product-2", 100.00m));
            _productRepository.AddAsync (new Product (Guid.NewGuid (), "Product-3", 100.00m));
            _productRepository.AddAsync (new Product (Guid.NewGuid (), "Product-4", 100.00m));
        }

        private void MockPosts () {
            _blogRepository.AddAsync(new BlogPost(Guid.NewGuid(), "Neque porro quisquam est qui dolorem ipsum", DateTime.Now, new Category(Guid.NewGuid(), "Fashion")));
            _blogRepository.AddAsync(new BlogPost(Guid.NewGuid(), "Neque porro quisquam est qui dolorem ipsum", DateTime.Now, new Category(Guid.NewGuid(), "Fashion")));
            _blogRepository.AddAsync(new BlogPost(Guid.NewGuid(), "Neque porro quisquam est qui dolorem ipsum", DateTime.Now, new Category(Guid.NewGuid(), "Fashion")));
        }

        private void MockCategories () {
            _categoryRepository.AddAsync(new Category(Guid.NewGuid(), "Down Jackets"));
            _categoryRepository.AddAsync(new Category(Guid.NewGuid(), "Hoodies"));
            _categoryRepository.AddAsync(new Category(Guid.NewGuid(), "Suits"));
            _categoryRepository.AddAsync(new Category(Guid.NewGuid(), "Jeans"));
            _categoryRepository.AddAsync(new Category(Guid.NewGuid(), "Casual Pants"));
            _categoryRepository.AddAsync(new Category(Guid.NewGuid(), "Sunglass"));
        }

    }

    public interface IStoreMockBuilder {
        void Mock ();
    }
}