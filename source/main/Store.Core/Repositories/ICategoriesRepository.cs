using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface ICategoriesRepository
    {
         Task AddAsync(Categorie categorie);
         Task<IEnumerable<string>> GetCategorieAsync();
    }
}