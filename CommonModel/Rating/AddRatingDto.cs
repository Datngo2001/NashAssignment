using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonModel.Rating
{
    public class AddRatingDto
    {
        public int ProductId { get; set; }
        public int Star { get; set; }
        public string Message { get; set; } = "";
    }
}