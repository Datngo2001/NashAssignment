
using DataAccess.Entities;
using AutoMapper;
using CommonModel.Category;
using CommonModel.Product;
using CommonModel.Rating;
using CommonModel.Image;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Category
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            //Product
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Images.Where(i => i.IsMain == true).Select(i => i.Url).FirstOrDefault() ?? ""));
            CreateMap<Product, ProductDetailDto>();
            CreateMap<Product, ProductSearchHintDto>()
                .ForMember(dest => dest.hint, opt => opt.MapFrom(src => src.Name));
            CreateMap<CreateProductDto, Product>()
                .ForMember(dest => dest.Categories, opt => opt.Ignore());
            CreateMap<UpdateProductDto, Product>()
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.Categories, opt => opt.Ignore());

            // Feature
            CreateMap<Feature, FeatureDto>();

            // Rating
            CreateMap<Rating, RatingDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.ApplicationUser));
            CreateMap<Rating, AddRatingResDto>();
            CreateMap<AddRatingDto, Rating>();

            // User
            CreateMap<ApplicationUser, RatingAuthorDto>();

            // Image
            CreateMap<Image, ImageDto>();
            CreateMap<ImageDto, Image>();
            CreateMap<CreateImageDto, Image>();
            CreateMap<UpdateProductImageDto, Image>()
                // if new image not map id
                .ForMember(dest => dest.Id, opt => opt.Condition(src => src.IsNew == false));
        }
    }
}