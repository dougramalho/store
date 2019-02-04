using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Domain.Category
{
    public interface ICategoryService
    {
        Task AddAsync (string category, bool featured);
        Task<IEnumerable<string>> GetAsync(); 
        Task<IEnumerable<string>> GetFeaturedAsync(); 
    }
}