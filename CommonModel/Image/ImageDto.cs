using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonModel.Image
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = "";
        public bool IsMain { get; set; }
    }
}