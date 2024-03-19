using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace TravelSite2API.Entities
{
    public class HotelRating
    {
        [Key]
        public int HotelRatingsID { get; set; }
        public int HotelID { get; set; }
        public int rating { get; set; }
        public string? userID { get; set; }
        public string? comments { get; set; }
    }
}
