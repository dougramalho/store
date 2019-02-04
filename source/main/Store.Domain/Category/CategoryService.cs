using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Domain.Category {
    public class CategoryService : ICategoryService {
        private readonly ICategoryRepository _repository;

        public CategoryService (ICategoryRepository repository) {
            _repository = repository;
        }

        public async Task AddAsync (string category, bool featured) {
            await _repository.AddAsync (new Store.Domain.Category.Category (Guid.NewGuid (), category, featured));
        }

        public async Task<IEnumerable<string>> GetAsync () => await _repository.GetAsync ();

        public async Task<IEnumerable<string>> GetFeaturedAsync() => await _repository.GetFeaturedAsync ();
    }
}