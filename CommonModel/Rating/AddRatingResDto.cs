using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModel.Rating
{
    public class AddRatingResDto
    {
        public int Id { get; set; }
        public int Star { get; set; }
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public DateTime CreateDate { get; set; }
    }
}
