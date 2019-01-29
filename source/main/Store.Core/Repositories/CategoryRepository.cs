using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ISet<Category> _categories = new HashSet<Category>();

        public async Task AddAsync(Category categorie)
        {
            _categories.Add(categorie);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<string>> GetCategorieAsync() => await Task.FromResult(_categories.Select(x => x.Name));
    }
}