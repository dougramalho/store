using System;
using System.Collections.Generic;

namespace Store.Core.Domain
{
    public class Cart : Entity
    {
        private ISet<Product> _products = new HashSet<Product> ();

        public IEnumerable<Product> Products {
            get => _products;
            set => _products = new HashSet<Product> ();
        }

        public Cart(Guid id){
            Id = id;
        }

        public void AddProduct(Product product){
            _products.Add(product);
        }
    }
}