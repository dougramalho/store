using System;

namespace Store.Domain.Blog {
    public class BlogPost : Entity {
        public string Text { get; protected set; }
        public DateTime PublishedAt { get; protected set; }

        public string Category { get; protected set; }

        protected BlogPost(){}

        public BlogPost(Guid id, string text, DateTime publishedAt){
            Text = text;
            PublishedAt = publishedAt;
            Id = id;
        }

        public BlogPost(Guid id, string text, DateTime publishedAt, string category)
        : this(id, text, publishedAt){
            Category = category;
        }

        public void AddCategory(string category){
            Category = category;
        }
    }
}