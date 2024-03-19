using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelSiteAPI.Repositories;
using TravelSiteAPI.Entities;

namespace TravelSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet("RoomGetAvailabilityByDateRangeAndHotelID/{startDate}/{endDate}/{hotelid}")]
        public async Task<ActionResult<List<Room>>> RoomGetAvailabilityByDateRangeAndHotelID(DateTime startDate, DateTime endDate, int hotelid)
        {
            var roomDetails = await _roomService.RoomGetAvailabilityByDateRangeAndHotelID(startDate, endDate, hotelid);
            if (roomDetails == null)
            {
                return NotFound();
            }
            return roomDetails;
        }
    }
}
