using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public string Star { get; set; } = "";
        public string Message { get; set; } = "";
        public DateTime CreateDate { get; set; }
    }
}