using System;

namespace Store.Domain.Contact {
    public class Contact : Entity {
        public string Name { get; protected set; }
        public string Email { get; protected set; }

        public Contact(Guid id, string name, string email){
            Id = id;
            Name = name;
            Email = email;
        }
    }
}