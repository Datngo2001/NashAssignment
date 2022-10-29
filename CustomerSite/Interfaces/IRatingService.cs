using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel;
using CommonModel.Rating;

namespace CustomerSite.Interfaces
{
    public interface IRatingService
    {
        Task<AddRatingResDto> AddRating(AddRatingDto addRatingDto, string accessToken);
        Task<PagingDto<RatingDto>> GetProductRating(int productId, int page);
    }
}