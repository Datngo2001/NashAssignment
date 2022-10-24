using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Policy = "ApiScope")]
    public class IdentityController : _APIController
    {
        [HttpGet]
        public ActionResult<List<Claim>> GetClaims()
        {
            return new JsonResult(User.Claims.Select(c => new { c.Type, c.Value }).ToList());
        }
    }
}