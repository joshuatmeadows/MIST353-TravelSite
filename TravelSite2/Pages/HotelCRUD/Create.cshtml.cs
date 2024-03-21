using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelSite2.Data;
using TravelSite2API.Entities;
using System.Text.Json;

namespace TravelSite2.Pages.HotelCRUD
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly TravelSite2.Data.ApplicationDbContext _context;

        public CreateModel(TravelSite2.Data.ApplicationDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Hotel Hotel { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { 
                return Page();
            }
                var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7095/api/Hotels");
                request.Content = new StringContent(JsonSerializer.Serialize(Hotel), Encoding.UTF8, "application/json");
                var client = _clientFactory.CreateClient();
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode) { 
                    return RedirectToPage("./Index");
                }
                else
                {
                    return Page();
                }


        }
    }
}
