using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonModel.Product
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int Star { get; set; }
        public string Message { get; set; } = "";
        public DateTime CreateDate { get; set; }
    }
}