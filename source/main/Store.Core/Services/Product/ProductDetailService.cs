using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Store.Core.Domain;
using Store.Core.DTO;
using Store.Core.Repositories;
using Store.Core.Repositories.Product;

namespace Store.Core.Services.Product
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductDetailService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDetailDTO>> GetAsync(string productName)
        {
            var product = await _productRepository.GetOrFailAsync(productName);
            List<ProductDetailDTO> detailsList = new List<ProductDetailDTO>();

            // foreach (var item in product.Details)
            // {
            //     detailsList.Add(_mapper.Map<ProductDetailDTO>(item));
            // }

            //var teste = detailsList.ProjectTo()

            return _mapper.Map<IEnumerable<ProductDetail>, IEnumerable<ProductDetailDTO>>(product.Details);
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