using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSite.Interfaces;
using CustomerSite.Extensions;

namespace CustomerSite.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory clientFactory;

        public CategoryService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
    }
}