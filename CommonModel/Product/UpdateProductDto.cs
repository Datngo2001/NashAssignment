using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Category;
using CommonModel.Image;

namespace CommonModel.Product
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public long Price { get; set; } = 0;
        public string Description { get; set; } = "";
        public List<UpdateProductImageDto> Images { get; set; } = new List<UpdateProductImageDto>();
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}