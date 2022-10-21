using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonModel.Product
{
    public class FeatureDto
    {
        public int Id { get; set; }
        public string Key { get; set; } = "";
        public string Value { get; set; } = "";
    }
}