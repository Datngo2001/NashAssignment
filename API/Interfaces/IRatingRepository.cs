using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Rating;

namespace API.Interfaces
{
    public interface IRatingRepository
    {
        Task<RatingDto> CreateRating(AddRatingDto addRatingDto, string userId);
    }
}