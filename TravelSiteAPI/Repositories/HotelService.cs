using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using TravelSiteAPI.Entities;
using TravelSiteAPI.Data;

namespace TravelSiteAPI.Repositories
{
    public class HotelService : IHotelService
    {
        private readonly DbContextClass _dbContext;
        public HotelService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Hotel>> GetHotelDetails(int hotelid)
        {
            var param = new SqlParameter("@HotelID", hotelid);
            var hotelDetails = await Task.Run(() => _dbContext.Hotel.FromSqlRaw("spHotelGetDetails @HotelID", param).ToListAsync());
            return hotelDetails;
        }

        public Task<List<Hotel>> HotelSearchByRadiusDateRange(decimal Latitude, decimal Longitude, DateTime startDate, DateTime endDate)
        {
            var LatitudeParm = new SqlParameter("@Latitude", Latitude);
            var LongitudeParm = new SqlParameter("@Longitude", Longitude);
            var StartDateParm = new SqlParameter("@StartDate", startDate);
            var EndDateParm = new SqlParameter("@EndDate", endDate);
            var hotelDetails = _dbContext.Hotel.FromSqlRaw("spHotelSearchByRadiusDateRange @Latitude, @Longitude, @StartDate, @EndDate", LatitudeParm, LongitudeParm, StartDateParm, EndDateParm).ToListAsync();
            return hotelDetails;
        }
    }
}
