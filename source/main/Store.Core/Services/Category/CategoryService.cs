using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities = Store.Core.Domain; 
using Store.Core.Repositories.Category;

namespace Store.Core.Services.Category {
    public class CategoryService : ICategoryService {
        private readonly ICategoryRepository _repository;

        public CategoryService (ICategoryRepository repository) {
            _repository = repository;
        }

        public async Task AddAsync (string category, bool featured) {
            await _repository.AddAsync (new Entities.Category (Guid.NewGuid (), category, featured));
        }

        public async Task<IEnumerable<string>> GetAsync () => await _repository.GetAsync ();

        public async Task<IEnumerable<string>> GetFeaturedAsync() => await _repository.GetFeaturedAsync ();
    }
}