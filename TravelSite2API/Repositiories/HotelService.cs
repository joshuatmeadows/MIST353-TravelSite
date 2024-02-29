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
    }
}
