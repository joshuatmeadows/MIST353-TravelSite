using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using TravelSiteAPI.Entities;
using TravelSiteAPI.Data;

namespace TravelSiteAPI.Repositories
{
    public class HotelRatingService : IHotelRatingService
    {
        private readonly DbContextClass _dbContext;
        public HotelRatingService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<HotelRating>> GetHotelRatings(int hotelid)
        {
            var param = new SqlParameter("@HotelID", hotelid);
            var hotelRatings = await Task.Run(() => _dbContext.HotelRating.FromSqlRaw("spHotelGetRatings @HotelID", param).ToListAsync());
            return hotelRatings;
        }
    }
}
