using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Store.Core.Domain;
using Store.Core.Repositories;
using Store.Core.Repositories.Blog;
using Store.Core.Repositories.Category;
using Store.Core.Repositories.Product;

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
            var highHeel = new Product (Guid.NewGuid (), "High Heel", 45.05m, DateTime.Now, true);
            highHeel.AddPhoto ("f-product-3.jpg", true);
            _productRepository.AddAsync (highHeel);

            var nike = new Product (Guid.NewGuid (), "Nike Max Air Vapor Power", 45.05m, DateTime.Now, true);
            nike.AddPhoto ("f-product-1.jpg", true);
            _productRepository.AddAsync (nike);

            var fossilWatch = new Product (Guid.NewGuid (), "Fossil Watch", 250m, DateTime.Now, true);
            fossilWatch.AddPhoto ("f-product-2.jpg", true);
            _productRepository.AddAsync (fossilWatch);

            var libero = new Product (Guid.NewGuid (), "Womens Libero", 40.00m, DateTime.Now, false);
            libero.AddPhoto ("l-product-1.jpg", false);
            _productRepository.AddAsync (libero);

            var summer = new Product (Guid.NewGuid (), "Summer Dress", 45.05m, DateTime.Now, false);
            summer.AddPhoto ("l-product-3.jpg", false);
            _productRepository.AddAsync (summer);

            var nikeShoes = new Product (Guid.NewGuid (), "Nike Shoes", 110m, DateTime.Now, false);
            nikeShoes.AddPhoto ("l-product-4.jpg", false);
            _productRepository.AddAsync (nikeShoes);

            var oxford = new Product (Guid.NewGuid (), "Oxford Shirt", 85.50m, DateTime.Now, false);
            oxford.AddPhoto ("l-product-5.jpg", false);
            _productRepository.AddAsync (oxford);

            var rick = new Product (Guid.NewGuid (), "Ricky Shirt", 45.05m, DateTime.Now, false);
            rick.AddPhoto ("l-product-8.jpg", false);
            _productRepository.AddAsync (rick);
        }

        private void MockPosts () {
            _blogRepository.AddAsync (new BlogPost (Guid.NewGuid (), "Neque porro quisquam est qui dolorem ipsum", DateTime.Now, new Category (Guid.NewGuid (), "Fashion")));
            _blogRepository.AddAsync (new BlogPost (Guid.NewGuid (), "Neque porro quisquam est qui dolorem ipsum", DateTime.Now, new Category (Guid.NewGuid (), "Fashion")));
            _blogRepository.AddAsync (new BlogPost (Guid.NewGuid (), "Neque porro quisquam est qui dolorem ipsum", DateTime.Now, new Category (Guid.NewGuid (), "Fashion")));
        }

        private void MockCategories () {
            _categoryRepository.AddAsync (new Category (Guid.NewGuid (), "Down Jackets"));
            _categoryRepository.AddAsync (new Category (Guid.NewGuid (), "Hoodies"));
            _categoryRepository.AddAsync (new Category (Guid.NewGuid (), "Suits"));
            _categoryRepository.AddAsync (new Category (Guid.NewGuid (), "Jeans"));
            _categoryRepository.AddAsync (new Category (Guid.NewGuid (), "Casual Pants"));
            _categoryRepository.AddAsync (new Category (Guid.NewGuid (), "Sunglass"));
        }

    }

    public interface IStoreMockBuilder {
        void Mock ();
    }
}