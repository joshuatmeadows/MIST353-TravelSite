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
    public class IndexModel : PageModel
    {
        private readonly TravelSite2.Data.ApplicationDbContext _context;

        public IndexModel(TravelSite2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Hotel> Hotel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Hotel = await _context.Hotel.ToListAsync();
        }
    }
}
