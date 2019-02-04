using System;
using System.Collections.Generic;

namespace Store.Domain.Cart
{
    public class Cart : Entity
    {
        private ISet<Store.Domain.Product.Product> _products = new HashSet<Store.Domain.Product.Product> ();

        public IEnumerable<Store.Domain.Product.Product> Products {
            get => _products;
            set => _products = new HashSet<Store.Domain.Product.Product> ();
        }

        public Cart(Guid id){
            Id = id;
        }

        public void AddProduct(Store.Domain.Product.Product product){
            _products.Add(product);
        }
    }
}