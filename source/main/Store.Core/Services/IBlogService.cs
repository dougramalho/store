using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.DTO;

namespace Store.Core.Services
{
    public interface IBlogService
    {
        Task<BlogPostDTO> GetAsync (Guid id);
        Task AddAsync (string text, DateTime publishedAt);

        Task<IEnumerable<BlogPostDTO>> GetPostsAsync ();
    }
}