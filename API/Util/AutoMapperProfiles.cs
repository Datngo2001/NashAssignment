
using DataAccess.Entities;
using AutoMapper;
using CommonModel.Category;
using CommonModel.Product;
using CommonModel.Rating;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductDetailDto>();
            CreateMap<Feature, FeatureDto>();
            CreateMap<Rating, RatingDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.ApplicationUser));
            CreateMap<Rating, AddRatingResDto>();
            CreateMap<ApplicationUser, RatingAuthorDto>();
            CreateMap<AddRatingDto, Rating>();
            CreateMap<Product, ProductSearchHintDto>()
                .ForMember(dest => dest.hint, opt => opt.MapFrom(src => src.Name));
            CreateMap<CreateProductDto, Product>();
        }
    }
}