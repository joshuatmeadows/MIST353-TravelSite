using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelSiteAPI.Repositories;
using TravelSiteAPI.Entities;

namespace TravelSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRatingsController : ControllerBase
    {
        private readonly IHotelRatingService _hotelRatingService;
        public HotelRatingsController(IHotelRatingService hotelRatingService)
        {
            _hotelRatingService = hotelRatingService;
        }
        [HttpGet("{hotelid}")]
        public async Task<ActionResult<List<HotelRating>>> GetHotelRatings(int hotelid)
        {
            var hotelRatings = await _hotelRatingService.GetHotelRatings(hotelid);
            if (hotelRatings == null)
            {
                return NotFound();
            }
            return hotelRatings;
        }
    }
}
