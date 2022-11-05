using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonModel.Image
{
    public class CreateImageDto
    {
        public string Url { get; set; } = "";
        public bool IsMain { get; set; }
    }
}