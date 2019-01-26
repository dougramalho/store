
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Core.Domain
{
    public class Product : Entity // Aggregate Root
    {
        private ISet<ProductDetail> _details = new HashSet<ProductDetail>();
        public string Name {get; protected set;}
        public decimal Price {get; protected set;}
        public IEnumerable<ProductDetail> Details 
        {
            get => _details;
            set => _details = new HashSet<ProductDetail>();
        }

        protected Product(){}

        public Product(Guid id, string name, decimal price)
        {
            Name = name;
            Price = price;
            Id = id;
        }

        public void AddDetail(string name, string value){
            if(Details.Any(x => x.Name == name)){
                throw new StoreException("detail_already_exists", $"Detail: {name} already exists in this product: {this.Name}");
            }
            _details.Add(new ProductDetail(name, value));
        }

        public void RemoveDetail(string name){
            var detail = GetDetail(name);
            _details.Remove(detail);
        }

        private ProductDetail GetDetail(string name){
            var item = Details.SingleOrDefault(x => x.Name == name);

            if(item == null)
                throw new StoreException("detail_not_found", $"Detail {name} was not found in this product");
            
            return item;
        }
    }
}