using System.Collections.Generic;
using System.Threading.Tasks;
using Entities = Store.Core.Domain; 

namespace Store.Core.Repositories.Category
{
    public interface ICategoryRepository
    {
         Task AddAsync(Entities.Category categorie);
         Task<IEnumerable<string>> GetCategorieAsync();
    }
}