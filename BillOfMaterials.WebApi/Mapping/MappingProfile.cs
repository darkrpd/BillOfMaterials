using AutoMapper;
using BillOfMaterials.Core.Models;
using BillOfMaterials.WebApi.DTO;

namespace BillOfMaterials.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();

            // Resource to Domain
            CreateMap<ProductDTO, Product>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
