using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface ICategoryRepository
    {
         Task AddAsync(Category categorie);
         Task<IEnumerable<string>> GetCategorieAsync();
    }
}