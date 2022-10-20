using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Feature
    {
        public int Id { get; set; }
        public string Key { get; set; } = "";
        public string Value { get; set; } = "";
        public Product Product { get; set; }
    }
}