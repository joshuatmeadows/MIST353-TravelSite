using System.ComponentModel.DataAnnotations;
namespace TravelSiteAPI.Entities
{
    public class Hotel
    {
        public int HotelID { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string? HotelType { get; set; }
        public string? Email { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

    }
}
