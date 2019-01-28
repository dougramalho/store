using System;

namespace Store.Core.Domain {
    public class BlogPost : Entity {
        public string Text { get; protected set; }
        public DateTime PublishedAt { get; protected set; }

        protected BlogPost(){}

        public BlogPost(Guid id, string text, DateTime publishedAt){
            Text = text;
            PublishedAt = publishedAt;
            Id = id;
        }
    }
}