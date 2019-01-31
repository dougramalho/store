using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories.Blog {
    public class BlogRepository : IBlogRepository {
        private readonly ISet<BlogPost> _posts = new HashSet<BlogPost> ();

        public async Task AddAsync (BlogPost post) {
            _posts.Add(post);
            await Task.CompletedTask;
        }

        public async Task<BlogPost> GetAsync (Guid id) => await Task.FromResult(_posts.FirstOrDefault(x => x.Id == id));

        public async Task<IEnumerable<BlogPost>> GetPostsAsync () => await Task.FromResult (_posts);
    }
}