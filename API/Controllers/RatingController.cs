using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using API.Interfaces;
using CommonModel;
using CommonModel.Rating;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RatingController : _APIController
    {
        private readonly IRatingRepository ratingRepository;
        private readonly UserManager<AppUser> userManager;
        public RatingController(IRatingRepository ratingRepository, UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            this.ratingRepository = ratingRepository;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Policy = "Customer")]
        [HttpPost]
        public async Task<AddRatingResDto> addRating([FromBody] AddRatingDto addRatingDto)
        {
            var userId = userManager.GetUserId(User);

            return await ratingRepository.CreateRating(addRatingDto, userId);
        }

        [HttpGet("product/{productId}")]
        public async Task<PagingDto<RatingDto>> getProductRating([FromRoute(Name = "productId")] int productId, [FromQuery(Name = "p")] int page)
        {
            var result = await ratingRepository.GetRatingByProductId(productId, page, 5);
            return result;
        }
    }
}