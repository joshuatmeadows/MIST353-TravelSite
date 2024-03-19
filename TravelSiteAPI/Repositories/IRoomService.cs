using TravelSiteAPI.Entities;

namespace TravelSiteAPI.Repositories
{
    public interface IRoomService
    {
        public Task<List<Room>> RoomGetAvailabilityByDateRangeAndHotelID(DateTime startDate, DateTime endDate,int hotelid);
    }
}
