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
        [Fact]
        public async Task GetAllCategories_ReturnCategoryDto()
        {
            // Arrange 
            var categoryDtos = new List<CategoryDto>{
                new CategoryDto(){ Id = 1, Name="Phone", Image="https:"},
                new CategoryDto(){ Id = 2, Name="Laptop", Image="https:"},
            };

            var categories = new List<Category>{
                new Category(){ Id = 1, Name="Phone", Image="https:"},
                new Category(){ Id = 2, Name="Laptop", Image="https:"},
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Category>>();
            mockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            mockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            mockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            mockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(() => categories.GetEnumerator());

            var mockCategoryDtosQueryable = new Mock<IQueryable<CategoryDto>>();

            var mockDbContext = new Mock<ApplicationDbContext>();
            mockDbContext.Setup(c => c.Categories).Returns(mockDbSet.Object);
            mockDbSet.Setup(m => m.ProjectTo<CategoryDto>(mapper.ConfigurationProvider)).Returns(mockCategoryDtosQueryable.Object);
            // mockCategoryDtosQueryable.Setup(mockDto => mockDto.ToListAsync()).ReturnsAsync(categoryDtos);

            var repo = new CategoryRepository(mockDbContext.Object, mapper);

            // Act
            var result = await repo.GetAllCategories();

            // Assert
            Assert.IsType<List<CategoryDto>>(result);
            Assert.Equal(categoryDtos, result);
        }
    }
}
