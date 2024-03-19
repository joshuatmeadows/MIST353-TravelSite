using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace TravelSite2.Pages
{
    public class photoUploaderModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public photoUploaderModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public int HotelID { get; set; }

        [BindProperty]
        public bool IsPrimary { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            byte[] photoBytes;
            using (var memoryStream = new MemoryStream())
            {
                await Photo.CopyToAsync(memoryStream);
                photoBytes = memoryStream.ToArray();
            }

            // Accessing the connection string from the appsettings.json
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO Photo (HotelID, Photo, IsPrimary) VALUES (@HotelID, @Photo, @IsPrimary)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HotelID", HotelID);
                    command.Parameters.AddWithValue("@Photo", photoBytes);
                    command.Parameters.AddWithValue("@IsPrimary", IsPrimary);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }

            return RedirectToPage("/Success"); // Redirect to a success page or another appropriate page
        }
    }

}
