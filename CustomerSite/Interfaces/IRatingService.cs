using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Rating;

namespace CustomerSite.Interfaces
{
    public interface IRatingService
    {
        Task<RatingDto> AddRating(AddRatingDto addRatingDto, string accessToken);
    }
}