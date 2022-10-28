using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Rating;
using CustomerSite.Interfaces;
using CustomerSite.Extensions;
using Microsoft.AspNetCore.Authentication;

namespace CustomerSite.Services
{
    public class RatingService : IRatingService
    {
        private readonly IHttpClientFactory clientFactory;

        public RatingService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<RatingDto> AddRating(AddRatingDto addRatingDto, string accessToken)
        {
            var httpClient = clientFactory.CreateClient();

            var result = await httpClient.PostApiAsync<AddRatingDto, RatingDto>("Rating", addRatingDto, accessToken);

            if (result == null)
            {
                throw new Exception($"Can not add Rating with message: {addRatingDto.Message}");
            }

            return result;
        }
    }
}