using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories.Blog {
    public interface IBlogRepository {
        Task<BlogPost> GetAsync (Guid id);
        Task AddAsync (BlogPost post);

        Task<IEnumerable<BlogPost>> GetPostsAsync (int quantity = int.MaxValue);
    }
}