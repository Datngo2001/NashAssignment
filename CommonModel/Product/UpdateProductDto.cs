using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Image;

namespace CommonModel.Product
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Image { get; set; } = "";
        public long Price { get; set; } = 0;
        public string Description { get; set; } = "";
        public List<CreateImageDto> Images { get; set; } = new List<CreateImageDto>();
    }
}