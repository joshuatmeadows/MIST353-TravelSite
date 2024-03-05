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
    }
}
