
using API.Entities;
using AutoMapper;
using CommonModel.Category;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}