using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravelSite2.Pages
{
    public class searchResultsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _clientFactory;
        public string JsonData { get; private set; }
        public searchResultsModel(ILogger<IndexModel> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }
            public async Task OnGetAsync()
            {
                try
                {
                    var apiKey = "";
                    var request = new HttpRequestMessage(HttpMethod.Get, "https://www.ncei.noaa.gov/cdo-web/api/v2/datasets");
                    request.Headers.Add("token", apiKey);

                    var client = _clientFactory.CreateClient();
                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        JsonData = await response.Content.ReadAsStringAsync();
                        _logger.LogInformation("API request successful.");
                        // Process the response
                    }
                    else
                    {
                        _logger.LogWarning($"API request failed with status code: {response.StatusCode}.");
                        // Handle failure
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while making the API request.");
                    // Handle or throw the exception
                }
            }
        }
    }
