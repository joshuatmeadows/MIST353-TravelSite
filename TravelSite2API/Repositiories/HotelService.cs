using TravelSite2API.Data;
using TravelSite2API.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TravelSite2API.Repositiories
{
    public class HotelService : IHotelService
    {
        private readonly DbContextClass _dbContextClass;
        public HotelService(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }
        public async Task<List<Hotel>> HotelGetDetails(int hotelid)
        {
            var param = new SqlParameter("@hotelid", hotelid);
            var hotelDetails = await Task.Run(() => _dbContextClass.Hotel.FromSqlRaw("exec spHotelGetDetails @hotelid", param).ToListAsync());
            return hotelDetails;
        }
        public async Task<List<Hotel>> HotelSearchByRadiusDateRange(decimal latitude, decimal longitude, DateTime startDate, DateTime endDate)
        {
            var latparam = new SqlParameter("@lat", latitude);
            var lonparam = new SqlParameter("@long", longitude);
            var startdate = new SqlParameter("@startDate", startDate);
            var enddate = new SqlParameter("@endDate", endDate);

            var hotelDetails = await Task.Run(() => _dbContextClass.Hotel.FromSqlRaw("exec spHotelSearchByRadiusDateRange @lat, @long, @startdate, @enddate", latparam, lonparam, startdate, enddate).ToListAsync());
            return hotelDetails;
        }
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
            var hotelDetails = await Task.Run(() => _dbContextClass.Database.ExecuteSqlRaw("exec spAddHotel @HotelAddress, @HotelZip, @HotelCity, @HotelState, @HotelCountry, @HotelName,  @HotelPhone,@HotelType, @HotelEmail, @HotelLatitude, @HotelLongitude", hotelAddress, hotelZip, hotelCity, hotelState, hotelCountry, hotelName, hotelPhone, hotelHotelType, hotelEmail, hotelLatitude, hotelLongitude));
            return hotelDetails;
        }
    }
}
