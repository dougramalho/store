using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Services.Category
{
    public interface ICategoryService
    {
        Task AddAsync(string category);
        Task<IEnumerable<string>> GetAsync(); 
        Task<IEnumerable<string>> GetFeaturedAsync(); 
    }
}