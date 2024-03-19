using TravelSite2API.Data;
using TravelSite2API.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TravelSite2API.Repositiories
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
            var param = new SqlParameter("HotelID", hotelid);
            var hotelRatings = await Task.Run(() => _dbContext.HotelRating.FromSqlRaw("spHotelGetRatings @HotelID", param).ToListAsync());
            return hotelRatings;
        }
    }
}
