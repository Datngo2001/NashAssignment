using API.Controllers;
using API.Interfaces;
using CommonModel.Category;
using DataAccess.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.API.Contoller
{
    public class CategoryControllerTest
    {
        private List<CategoryDto> categories = new List<CategoryDto>{
            new CategoryDto(){ Id = 1, Name="Bill", Image=""},
            new CategoryDto(){ Id = 2, Name="Steve", Image=""},
            new CategoryDto(){ Id = 3, Name="Ram", Image=""},
            new CategoryDto(){ Id = 4, Name="Abdul", Image=""}
        };

        [Fact]
        public async Task GetAll_ReturnAllCategory()
        {
            // Arrange 
            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(repo => repo.GetAllCategories()).ReturnsAsync(categories);
            var controller = new CategoryController(mockRepo.Object);

            // Act
            var result = await controller.getAll();

            // Assert
            Assert.IsType<List<CategoryDto>>(result.Value);
            Assert.Equal(categories, result.Value);
        }

        [Fact]
        public async Task CreateCategory_NameIsPhone_ReturnNewCategoryDto()
        {
            // Arrange 
            var createCategoryDto = new CreateCategoryDto() { Name="Phone", Image= "qwerty" };
            var categoryDto = new CategoryDto() { Id=1, Name="Phone", Image= "qwerty" };
            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(repo => repo.CreateCategory(createCategoryDto)).ReturnsAsync(categoryDto);

            var controller = new CategoryController(mockRepo.Object);

            // Act
            var result = await controller.CreateCategory(createCategoryDto);

            // Assert
            Assert.Equal(categoryDto, result.Value);
        }

    }
}
