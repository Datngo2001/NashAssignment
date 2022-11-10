using API.Controllers;
using API.Helpers;
using API.Interfaces;
using API.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CommonModel.Category;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.API.Repo
{
    public class CategoryRepositoryTest
    {
        private readonly IMapper mapper;

        private List<CategoryDto> categoryDtos = new List<CategoryDto>{
            new CategoryDto(){ Id = 1, Name="Phone", Image="https:"},
            new CategoryDto(){ Id = 2, Name="Laptop", Image="https:"},
        };

        public CategoryRepositoryTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            this.mapper = mapper;
        }
        //[Fact]
        //public async Task GetAllCategories_ReturnCategoryDto()
        //{
        //    // Arrange 
        //    var categoryDtos = new List<CategoryDto>{
        //        new CategoryDto(){ Id = 1, Name="Phone", Image="https:"},
        //        new CategoryDto(){ Id = 2, Name="Laptop", Image="https:"},
        //    };

        //    var mockDbSet = new Mock<DbSet<Category>>();
        //    var mockQueryable = new Mock<IQueryable<CategoryDto>>();
        //    var mockDbContext = new Mock<ApplicationDbContext>();

        //    mockDbContext.Setup(c => c.Categories).Returns(mockDbSet.Object);
        //    mockDbSet.Setup(m => m.ProjectTo<CategoryDto>(mapper.ConfigurationProvider))
        //        .Returns(mockQueryable.Object);
        //    mockQueryable.Setup(m => m.ToList()).Returns(categoryDtos);

        //    var repo = new CategoryRepository(mockDbContext.Object, mapper);

        //    // Act
        //    var result = await repo.GetAllCategories();

        //    // Assert
        //    Assert.IsType<List<CategoryDto>>(result);
        //    Assert.Equal(categoryDtos, result);
        //}
    }
}
