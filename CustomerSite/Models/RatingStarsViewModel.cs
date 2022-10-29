using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Models
{
    public class RatingStarsViewModel
    {
        public string Id { get; set; } = "";
        public int Stars { get; set; } = 0;
        public int Max { get; set; } = 5;
        public bool Disable { get; set; } = false;
        public StarSize Size { get; set; } = StarSize.Small;
    }

    public enum StarSize
    {
        Small,
        Medium,
        Large
    }
}