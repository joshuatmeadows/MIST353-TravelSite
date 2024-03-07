using TravelSiteAPI.Entities;

namespace TravelSiteAPI.Repositories
{
    public interface IHotelService
    {
        public Task<List<Hotel>> GetHotelDetails(int hotelid);
        public Task<List<Hotel>> HotelSearchByRadiusDateRange( decimal Latitude, decimal Longitude, DateTime startDate, DateTime endDate);
    }
}
