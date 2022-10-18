using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonModel
{
    public class Paging<T>
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 10;
        public int TotalPage { get; set; } = 0;
        public List<T> Items { get; set; } = new List<T>();
    }
}