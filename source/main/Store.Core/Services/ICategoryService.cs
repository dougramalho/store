using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Services
{
    public interface ICategoryService
    {
        Task AddAsync(string category);
        Task<IEnumerable<string>> GetCategoriesAsync(); 
    }
}