using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Models
{
    public class PagingViewModel
    {
        public int page { get; set; }
        public int totalPage { get; set; }
        public Func<int, string> getLink { get; set; } = p => $"{p}";
    }
}