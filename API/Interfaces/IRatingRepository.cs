using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel;
using CommonModel.Rating;

namespace API.Interfaces
{
    public interface IRatingRepository
    {
        Task<RatingDto> CreateRating(AddRatingDto addRatingDto, string userId);
        Task<PagingDto<RatingDto>> GetRatingByProductId(int productId, int page, int limit);
    }
}