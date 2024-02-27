using TravelSiteAPI.Entities;

namespace TravelSiteAPI.Repositories
{
    public interface IHotelService
    {
        public Task<List<Hotel>> GetHotelDetails(int hotelid);
    }
}
