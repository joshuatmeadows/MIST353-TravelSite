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
        // add hotel
        public async Task<int> AddHotel(Hotel hotel)
        {
            var hotelName = new SqlParameter("@HotelName", hotel.Name);
            var hotelAddress = new SqlParameter("@HotelAddress", hotel.Address);
            var hotelCity = new SqlParameter("@HotelCity", hotel.City);
            var hotelState = new SqlParameter("@HotelState", hotel.State);
            var hotelCountry = new SqlParameter("@HotelCountry", hotel.Country);
            var hotelZip = new SqlParameter("@HotelZip", hotel.Zipcode);
            var hotelPhone = new SqlParameter("@HotelPhone", hotel.Phone);
            var hotelEmail = new SqlParameter("@HotelEmail", hotel.Email);
            var hotelLatitude = new SqlParameter("@HotelLongitude", hotel.Latitude);
            var hotelLongitude = new SqlParameter("@HotelLatitude", hotel.Longitude);
            var hotelHotelType = new SqlParameter("@HotelType", hotel.HotelType);
            var hotelDetails = await Task.Run(() => _dbContext.Database.ExecuteSqlRaw("spAddHotel @HotelAddress, @HotelZip, @HotelCity, @HotelState, @HotelCountry, @HotelName,  @HotelPhone,@HotelType, @HotelEmail, @HotelLatitude, @HotelLongitude", hotelAddress, hotelZip, hotelCity, hotelState, hotelCountry, hotelName,  hotelPhone, hotelHotelType, hotelEmail, hotelLatitude, hotelLongitude));
            return hotelDetails;
        }
    }
}
