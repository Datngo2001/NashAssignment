using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Rating;
using CustomerSite.Interfaces;
using CustomerSite.Extensions;
using Microsoft.AspNetCore.Authentication;
using CommonModel;

namespace CustomerSite.Services
{
    public class RatingService : IRatingService
    {
        private readonly IHttpClientFactory clientFactory;

        public RatingService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<AddRatingResDto> AddRating(AddRatingDto addRatingDto, string accessToken)
        {
            var httpClient = clientFactory.CreateClient();

            var result = await httpClient.PostApiAsync<AddRatingDto, AddRatingResDto>("Rating", addRatingDto, accessToken);

            if (result == null)
            {
                throw new Exception($"Can not add Rating with message: {addRatingDto.Message}");
            }

            return result;
        }

        public async Task<PagingDto<RatingDto>> GetProductRating(int productId, int page)
        {
            var httpClient = clientFactory.CreateClient();

            var result = await httpClient.GetApiAsync<PagingDto<RatingDto>>($"Rating/product/{productId}?p={page}");

            if (result == null)
            {
                throw new Exception($"Can not get Rating of product id: {productId}");
            }

            return result;
        }
    }
}