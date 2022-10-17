using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using API.Interfaces;
using CommonModel.Category;
using API.Controllers;

namespace ApiTest
{
    public class CategoryControllerTest
    {
        private List<CategoryDto> categories = new List<CategoryDto>{
            new CategoryDto(){ Id = 1, Name="Bill", Image=""},
            new CategoryDto(){ Id = 2, Name="Steve", Image=""},
            new CategoryDto(){ Id = 3, Name="Ram", Image=""},
            new CategoryDto(){ Id = 4, Name="Abdul", Image=""}
        };

        public async Task Get_All_Category()
        {
            // Arrange 
            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(repo => repo.GetAllCategories()).ReturnsAsync(categories);
            var controller = new CategoryController(mockRepo.Object);

            // Act
            var result = await controller.getAll();

            // Assert
            Assert.IsType<List<CategoryDto>>(result.Value);
            Assert.Equal(categories.Count, result.Value.Count);
        }
    }
}