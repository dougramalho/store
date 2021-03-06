
using System;

namespace Store.Core.Domain
{
    public class ProductDetail : Entity
    {
        public string Name {get; protected set;}
        public string Value {get; protected set;}

        protected ProductDetail(){}

        public ProductDetail(string name, string value){
            Name = name;
            Value = value;
        }
    }
}