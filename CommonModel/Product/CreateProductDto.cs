using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Category;
using CommonModel.Image;

namespace CommonModel.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; } = "";
        public string Image { get; set; } = "";
        public long Price { get; set; } = 0;
        public string Description { get; set; } = "";
        public List<CreateImageDto> Images { get; set; } = new List<CreateImageDto>();
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}