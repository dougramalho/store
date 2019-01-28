using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ISet<Categorie> _categories = new HashSet<Categorie>();

        public async Task AddAsync(Categorie categorie)
        {
            _categories.Add(categorie);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<string>> GetCategorieAsync() => await Task.FromResult(_categories.Select(x => x.Name));
    }
}