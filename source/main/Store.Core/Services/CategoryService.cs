using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Core.Services
{
    public class CategoryService : ICategoryService
    {
        public Task AddAsync(string category)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> GetCategoriesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}