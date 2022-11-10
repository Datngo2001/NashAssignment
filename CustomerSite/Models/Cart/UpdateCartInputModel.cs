using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Models.Cart
{
    public class UpdateCartInputModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 0;
    }
}