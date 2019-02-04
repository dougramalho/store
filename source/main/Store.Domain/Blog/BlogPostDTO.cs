using System;

namespace Store.Domain.Blog {
    public class BlogPostDTO {
        public string Text { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Category { get; set; }
    }
}