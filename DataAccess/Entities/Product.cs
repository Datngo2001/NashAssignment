using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public long Price { get; set; } = 0;
        public string Description { get; set; } = "";
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Feature> Features { get; set; } = new List<Feature>();
        public List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}