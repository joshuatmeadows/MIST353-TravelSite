﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelSiteAPI.Repositories;
using TravelSiteAPI.Entities;

namespace TravelSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        [HttpGet("{hotelid}")]
        public async Task<ActionResult<List<Hotel>>> GetHotelDetails(int hotelid)
        {
            var hotelDetails = await _hotelService.GetHotelDetails(hotelid);
            if (hotelDetails == null)
            {
                return NotFound();
            }
            return hotelDetails;
        }
    }
}
