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
    }
}
