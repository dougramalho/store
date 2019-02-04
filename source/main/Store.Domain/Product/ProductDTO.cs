
using System;
using System.Collections.Generic;

namespace Store.Domain.Product
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Featured { get; set; }

        public IList<string> Details { get; set; }

        public ProductDTO() { }
    }
}