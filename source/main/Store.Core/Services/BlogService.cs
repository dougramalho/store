using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Store.Core.Domain;
using Store.Core.DTO;
using Store.Core.Repositories;

namespace Store.Core.Services {
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

        public async Task<IEnumerable<BlogPostDTO>> GetPostsAsync () {
            var posts = await _blogRepository.GetPostsAsync();
            return _mapper.Map<IEnumerable<BlogPost>, IEnumerable<BlogPostDTO>>(posts);
        }
    }
}