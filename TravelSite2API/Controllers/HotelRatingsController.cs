using Microsoft.AspNetCore.Mvc;
using TravelSite2API.Entities;
using TravelSite2API.Repositiories;

namespace TravelSite2API.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class HotelRatingsController : ControllerBase
    {
        private readonly IHotelRatingService _HotelRatingService;
        public HotelRatingsController(IHotelRatingService hotelRatingService)
        {
            _HotelRatingService = hotelRatingService;
        }
        [HttpGet("{hotelid}")]
        public async Task<ActionResult<List<HotelRating>>> GetHotelRatings(int hotelid)
        {
            var hotelRatings = await _HotelRatingService.GetHotelRatings(hotelid);
            return hotelRatings;
        }
    }
}
