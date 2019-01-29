using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;
using Store.Core.Repositories;

namespace Store.Core.Services {
    public class CategoryService : ICategoryService {
        private readonly ICategoryRepository _repository;

        public CategoryService (ICategoryRepository repository) {
            _repository = repository;
        }

        public async Task AddAsync (string category) {
            await _repository.AddAsync (new Category (Guid.NewGuid (), category));
        }

        public async Task<IEnumerable<string>> GetCategoriesAsync () => await _repository.GetCategorieAsync ();
    }
}