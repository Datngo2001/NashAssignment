
using API.Entities;
using AutoMapper;
using CommonModel.Category;
using CommonModel.Product;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();
            // CreateMap<List<Product>, List<ProductDto>>();
            CreateMap<Product, ProductSearchHintDto>()
                .ForMember(dest => dest.hint, opt => opt.MapFrom(src => src.Name));
        }
    }
}