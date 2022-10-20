using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Category;

namespace CommonModel.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Image { get; set; } = "";
        public long Price { get; set; } = 0;
    }
}