using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Category;

namespace Store.Core.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ISet<Store.Domain.Category.Category> _categories = new HashSet<Store.Domain.Category.Category>();

        public async Task AddAsync(Store.Domain.Category.Category category)
        {
            _categories.Add(category);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<string>> GetAsync() => await Task.FromResult(_categories.Select(x => x.Name));

        public async Task<IEnumerable<string>> GetFeaturedAsync() => await Task.FromResult(_categories.Where(x => x.Featured).Select(x => x.Name));
    }
}