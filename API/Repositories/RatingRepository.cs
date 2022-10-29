using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CommonModel;
using CommonModel.Rating;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public RatingRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }


        public async Task<AddRatingResDto> CreateRating(AddRatingDto addRatingDto, string userId)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == addRatingDto.ProductId);
            if (product == null)
            {
                throw new Exception($"Can not find product with id: {addRatingDto.ProductId}");
            }

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception($"Can not find user with id: {userId}");
            }

            var rating = mapper.Map<Rating>(addRatingDto);
            rating.ApplicationUser = user;
            product.Ratings.Add(rating);

            await dbContext.SaveChangesAsync();

            return mapper.Map<AddRatingResDto>(rating);
        }

        public async Task<PagingDto<RatingDto>> GetRatingByProductId(int productId, int page, int limit)
        {
            var queryable = dbContext.Ratings.Include(r => r.ApplicationUser).Where(p => p.Product.Id == productId);

            var ratings = await queryable
                .OrderByDescending(r => r.CreateDate)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ProjectTo<RatingDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            var count = await queryable.CountAsync();

            if (ratings == null)
            {
                ratings = new List<RatingDto>();
            }

            return new PagingDto<RatingDto>()
            {
                Page = page,
                Items = ratings.ToList(),
                TotalPage = count / limit + 1,
            };
        }
    }
}