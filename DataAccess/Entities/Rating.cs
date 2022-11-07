using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int Star { get; set; }
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public DateTime CreateDate { get; set; }
        public AppUser AppUser { get; set; } = new AppUser();
        public Product Product { get; set; } = new Product();
    }
}