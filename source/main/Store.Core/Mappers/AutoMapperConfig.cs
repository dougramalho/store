using System.Linq;
using AutoMapper;
using Store.Core.Domain;
using Store.Core.DTO;

namespace Store.Core.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>().ForMember(m => m.Details, m => m.MapFrom(p => p.Details.Select(x => x.Name).OrderBy(i => i)));

                cfg.CreateMap<ProductDetail, ProductDetailDTO>();

            });

            return config.CreateMapper();
        }
    }
}