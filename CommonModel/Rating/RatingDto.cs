using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonModel.Rating
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int Star { get; set; }
        public string Message { get; set; } = "";
        public DateTime CreateDate { get; set; }
        public RatingAuthorDto Author { get; set; }
    }
}