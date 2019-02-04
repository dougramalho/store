using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Blog;

namespace Store.Infrastructure.Blog {
    public class BlogRepository : IBlogRepository {
        private readonly ISet<Store.Domain.Blog.BlogPost> _posts = new HashSet<Store.Domain.Blog.BlogPost> ();

        public async Task AddAsync (Store.Domain.Blog.BlogPost post) {
            _posts.Add(post);
            await Task.CompletedTask;
        }

        public async Task<Store.Domain.Blog.BlogPost> GetAsync (Guid id) => await Task.FromResult(_posts.FirstOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Store.Domain.Blog.BlogPost>> GetPostsAsync (int quantity = int.MaxValue) => await Task.FromResult (_posts.Take(quantity));
    }
}