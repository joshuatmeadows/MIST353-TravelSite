using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravelSite2.Pages
{
    public class searchResultsModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public string JsonData { get; set; }

        public searchResultsModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task OnGetAsync()
        {
            var apiKey = "uZnzwcAwCLugMJGYsSejdFxmfhQWXTtI";
            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.ncei.noaa.gov/cdo-web/api/v2/datasets");
            request.Headers.Add("token", apiKey);

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            JsonData = await response.Content.ReadAsStringAsync();
        }

    }
}
