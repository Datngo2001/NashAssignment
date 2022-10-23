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
        public string Image { get; set; } = "";
        public long Price { get; set; } = 0;
        public string Description { get; set; } = "";
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Feature> Features { get; set; } = new List<Feature>();
        public List<Rating> Rattings { get; set; } = new List<Rating>();
    }
}