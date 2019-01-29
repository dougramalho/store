using System;

namespace Store.Core.Domain {
    public class Category : Entity {
        public string Name { get; protected set; }
        protected Category () { }

        public Category (Guid id, string name) {
            Name = name;
            Id = id;
        }
    }
}