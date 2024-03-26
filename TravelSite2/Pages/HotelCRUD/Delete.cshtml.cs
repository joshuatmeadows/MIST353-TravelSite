using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelSite2.Data;
using TravelSiteAPI.Entities;

namespace TravelSite2.Pages.Test
{
    public class DeleteModel : PageModel
    {
        private readonly TravelSite2.Data.ApplicationDbContext _context;

        public DeleteModel(TravelSite2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hotel Hotel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel.FirstOrDefaultAsync(m => m.HotelId == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel != null)
            {
                Hotel = hotel;
                _context.Hotel.Remove(Hotel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
