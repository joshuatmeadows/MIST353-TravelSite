using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelSite2.Data;
using TravelSite2API.Entities;

namespace TravelSite2.Pages.HotelCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly TravelSite2.Data.ApplicationDbContext _context;

        public DetailsModel(TravelSite2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Hotel Hotel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel.FirstOrDefaultAsync(m => m.HotelID == id);
            if (hotel == null)
            {
                return NotFound();
            }
            else
            {
                Hotel = hotel;
            }
            return Page();
        }
    }
}
