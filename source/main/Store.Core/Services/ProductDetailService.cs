using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Core.DTO;
using Store.Core.Repositories;

namespace Store.Core.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductRepository _productRepository;

        public ProductDetailService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDetailDTO>> GetAsync(string productName)
        {
            var product = await _productRepository.GetOrFailAsync(productName);
            List<ProductDetailDTO> detailsList = new List<ProductDetailDTO>();

            foreach (var item in product.Details)
            {
                detailsList.Add(new ProductDetailDTO()
                {
                    Name = item.Name,
                    Value = item.Value
                });
            }

            return detailsList;
        }

        public async Task<IEnumerable<string>> GetNamesAsync(string productName)
        {
            var product = await _productRepository.GetOrFailAsync(productName);

            return product.Details.Select(x => x.Name);
        }

        public async Task AddAsync(string productName, string name, string value)
        {
            var product = await _productRepository.GetOrFailAsync(productName);
            product.AddDetail(name, value);
        }

        public async Task RemoveAsync(string productname, string name)
        {
            var product = await _productRepository.GetOrFailAsync(productname);
            product.RemoveDetail(name);

            await _productRepository.UpdateAsync(product);
        }
    }
}