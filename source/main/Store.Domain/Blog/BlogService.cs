using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;


namespace Store.Domain.Blog {
    public class BlogService : IBlogService {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService (IBlogRepository repository, IMapper mapper) {
            _blogRepository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync (string text, DateTime publishedAt) {
            await _blogRepository.AddAsync (new BlogPost (Guid.NewGuid (), text, publishedAt));
        }

        public async Task<BlogPostDTO> GetAsync (Guid id) {
            var post = await _blogRepository.GetAsync (id);
            return _mapper.Map<BlogPostDTO> (post);
        }

        public async Task<IEnumerable<BlogPostDTO>> GetLatestPostsAsync(int quantity)
        {
            var posts = await _blogRepository.GetPostsAsync(quantity);
            return _mapper.Map<IEnumerable<BlogPost>, IEnumerable<BlogPostDTO>>(posts);
        }

        public async Task<IEnumerable<BlogPostDTO>> GetPostsAsync () {
            var posts = await _blogRepository.GetPostsAsync();
            return _mapper.Map<IEnumerable<BlogPost>, IEnumerable<BlogPostDTO>>(posts);
        }
    }
}