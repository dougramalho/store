using System;

namespace Store.Core.Domain {
    public class Categorie : Entity {
        public string Name { get; protected set; }
        protected Categorie () { }

        public Categorie (Guid id, string name) {
            Name = name;
            Id = id;
        }
    }
}