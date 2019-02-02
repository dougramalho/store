using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities = Store.Core.Domain; 

namespace Store.Core.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ISet<Entities.Category> _categories = new HashSet<Entities.Category>();

        public async Task AddAsync(Entities.Category categorie)
        {
            _categories.Add(categorie);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<string>> GetAsync() => await Task.FromResult(_categories.Select(x => x.Name));

        public async Task<IEnumerable<string>> GetFeaturedAsync() => await Task.FromResult(_categories.Where(x => x.Featured).Select(x => x.Name));
    }
}