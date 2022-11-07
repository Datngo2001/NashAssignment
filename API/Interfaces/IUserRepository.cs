using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel;
using CommonModel.User;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        Task<PagingDto<AppUserDto>> SearchCustomer(string query, int page, int limit);
    }
}