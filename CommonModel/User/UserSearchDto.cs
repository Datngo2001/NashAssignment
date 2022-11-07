using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonModel.User
{
    public class UserSearchDto
    {
        public string Query { get; set; } = "";
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 10;
    }
}