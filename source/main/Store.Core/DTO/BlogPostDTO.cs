using System;

namespace Store.Core.DTO {
    public class BlogPostDTO {
        public string Text { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Category { get; set; }
    }
}