using Microsoft.AspNetCore.Mvc;
using TravelSite2API.Entities;
using TravelSite2API.Repositiories;

namespace TravelSite2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : Controller
    {
        private readonly IHotelService hotelService;
        public HotelsController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }
        [HttpGet("{hotelid}")]
        public async Task<List<Hotel>> HotelGetDetails(int hotelid)
        {
            var hotelDetails = await hotelService.HotelGetDetails(hotelid);
            if (hotelDetails == null)
            {
                //return NotFound();
            }
            return hotelDetails;
        }
        [HttpGet("api/HotelSearchByRadiusDateRange/latitude={latitude}&longitude={longitude}&startdate={startDate}&enddate={endDate}")]
        public async Task<List<Hotel>> HotelSearchByRadiusDateRange(decimal latitude, decimal longitude, DateTime startDate, DateTime endDate)
        {
            var hotelDetails = await hotelService.HotelSearchByRadiusDateRange(latitude, longitude, startDate, endDate);
            if (hotelDetails == null)
            {
                //return NotFound();
            }
            return hotelDetails;
        }


    }
}
