using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Models
{
    public class PageButtonViewModel
    {
        public string text { get; set; } = "";
        public string link { get; set; } = "";
        public string activeClass { get; set; } = "";
    }
}