using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Domain.Product
{
    public interface IProductDetailService
    {
        Task<IEnumerable<ProductDetailDTO>> GetAsync(string productName);
        Task<IEnumerable<string>> GetNamesAsync(string productName);
        Task AddAsync(string productName, string name, string value);
        Task RemoveAsync(string productname, string name);
    }
}