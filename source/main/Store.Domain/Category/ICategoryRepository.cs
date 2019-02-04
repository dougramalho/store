using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Domain.Category
{
    public interface ICategoryRepository
    {
         Task AddAsync(Category categorie);
         Task<IEnumerable<string>> GetAsync();

         Task<IEnumerable<string>> GetFeaturedAsync();
    }
}