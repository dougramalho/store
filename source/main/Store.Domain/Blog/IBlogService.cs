using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Domain.Blog
{
    public interface IBlogService
    {
        Task<BlogPostDTO> GetAsync (Guid id);
        Task AddAsync (string text, DateTime publishedAt);

        Task<IEnumerable<BlogPostDTO>> GetPostsAsync ();

        Task<IEnumerable<BlogPostDTO>> GetLatestPostsAsync (int quantity);
    }
}