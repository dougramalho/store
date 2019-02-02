using System;

namespace Store.Core.Domain {
    public class Category : Entity {
        public string Name { get; protected set; }
        public bool Featured {get; protected set;}
        protected Category () { }

        public Category (Guid id, string name, bool featured) {
            Name = name;
            Id = id;
            Featured = featured;
        }
    }
}