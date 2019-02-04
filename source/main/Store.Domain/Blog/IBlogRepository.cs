using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Domain.Blog {
    public interface IBlogRepository {
        Task<BlogPost> GetAsync (Guid id);
        Task AddAsync (BlogPost post);

        Task<IEnumerable<BlogPost>> GetPostsAsync (int quantity = int.MaxValue);
    }
}