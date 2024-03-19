using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using TravelSiteAPI.Entities;
using TravelSiteAPI.Data;

namespace TravelSiteAPI.Repositories
{
    public class RoomService: IRoomService
    {
        private readonly DbContextClass _dbContext;
        public RoomService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Room>> RoomGetAvailabilityByDateRangeAndHotelID(DateTime startDate, DateTime endDate, int hotelid)
        {
            var param1 = new SqlParameter("@startDate", startDate);
            var param2 = new SqlParameter("@endDate", endDate);
            var param3 = new SqlParameter("@HotelID", hotelid);
            var rooms = await Task.Run(() => _dbContext.Room.FromSqlRaw("spRoomGetAvailabilityByDateRangeAndHotelID @startDate, @endDate, @HotelID", param1,param2, param3).ToListAsync());
            return rooms;
        }
    }
}
