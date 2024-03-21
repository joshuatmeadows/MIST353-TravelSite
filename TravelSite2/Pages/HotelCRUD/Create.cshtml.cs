using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelSite2.Data;
using TravelSiteAPI.Entities;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace TravelSite2.Pages.Test
{
    public class CreateModel : PageModel
    {
        private readonly TravelSite2.Data.ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _clientFactory;
        public CreateModel(TravelSite2.Data.ApplicationDbContext context, ILogger<IndexModel> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7236/api/Hotels");
            request.Content = new StringContent(JsonSerializer.Serialize(Hotel), Encoding.UTF8, "application/json");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("API request successful.");
                return RedirectToPage("./Index");
            }
            else {                 _logger.LogWarning($"API request failed with status code: {response.StatusCode}.");
                           return Page();
                       }


        }
    }
}
