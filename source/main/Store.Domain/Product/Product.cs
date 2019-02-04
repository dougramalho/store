using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Domain.Product {
    public class Product : Entity // Aggregate Root
    {
        private ISet<ProductDetail> _details = new HashSet<ProductDetail> ();
        private ISet<PhotoContent> _album = new HashSet<PhotoContent> ();
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public bool Available { get; protected set; }
        public bool Featured { get; protected set; }
        public DateTime PublishedAt { get; protected set; }

        public IEnumerable<ProductDetail> Details {
            get => _details;
            set => _details = new HashSet<ProductDetail> ();
        }

        public IEnumerable<PhotoContent> Album {
            get => _album;
            set => _album = new HashSet<PhotoContent> ();
        }

        protected Product () { }

        protected Product (Guid id, string name, decimal price) {
            Name = name;
            Price = price;
            Id = id;
        }

        protected Product (Guid id, string name, decimal price, DateTime publishedAt) : this (id, name, price) {
            PublishedAt = publishedAt;
        }

        public Product (Guid id, string name, decimal price, DateTime publishedAt, bool featured) : this (id, name, price, publishedAt) {
            Featured = featured;
        }

        public void AddPhoto (string url, bool starred) {
            if (Album.Any (x => x.Url == url)) {
                throw new StoreException ("photo_already_exists", $"Detail: {url} already exists in this product: {this.Name}");
            }
            _album.Add (new PhotoContent (url, starred));
        }

        public void AddDetail (string name, string value) {
            if (Details.Any (x => x.Name == name)) {
                throw new StoreException ("detail_already_exists", $"Detail: {name} already exists in this product: {this.Name}");
            }
            _details.Add (new ProductDetail (name, value));
        }

        public void RemoveDetail (string name) {
            var detail = GetDetail (name);
            _details.Remove (detail);
        }

        private ProductDetail GetDetail (string name) {
            var item = Details.SingleOrDefault (x => x.Name == name);

            if (item == null)
                throw new StoreException ("detail_not_found", $"Detail {name} was not found in this product");

            return item;
        }
    }
}