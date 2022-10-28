using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using CommonModel.Rating;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RatingController : _APIController
    {
        private readonly IRatingRepository ratingRepository;
        private readonly UserManager<ApplicationUser> userManager;
        public RatingController(IRatingRepository ratingRepository, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.ratingRepository = ratingRepository;
        }

        [Authorize(Policy = "ApiScope", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<RatingDto> addRating([FromBody] AddRatingDto addRatingDto)
        {
            var userId = userManager.GetUserId(User);

            return await ratingRepository.CreateRating(addRatingDto, userId);
        }
    }
}