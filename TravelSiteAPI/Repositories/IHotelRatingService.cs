using TravelSiteAPI.Entities;

namespace TravelSiteAPI.Repositories
{
    public interface IHotelRatingService
    {
        public Task<List<HotelRating>> GetHotelRatings(int hotelid);
    }
}
