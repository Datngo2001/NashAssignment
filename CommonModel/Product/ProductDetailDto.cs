using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Category;
using CommonModel.Rating;

namespace CommonModel.Product
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Image { get; set; } = "";
        public long Price { get; set; } = 0;
        public string Description { get; set; } = "";
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public List<FeatureDto> Features { get; set; } = new List<FeatureDto>();
        public List<RatingDto> Ratings { get; set; } = new List<RatingDto>();
    }
}