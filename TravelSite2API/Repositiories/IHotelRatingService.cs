using TravelSite2API.Entities;

namespace TravelSite2API.Repositiories
{
    public interface IHotelRatingService
    {
        public Task<List<HotelRating>> GetHotelRatings(int hotelid);
    }
}
