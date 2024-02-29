using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelSite2API.Entities
{
    public class Hotel
    {
        public int HotelID { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string Zipcode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        public string HotelType { get; set; }

        public string Email { get; set; } // It's a good practice to follow C# naming conventions, thus 'email' should be 'Email'

        [Column(TypeName = "decimal(9, 6)")]
        public decimal? Latitude { get; set; }

        [Column(TypeName = "decimal(9, 6)")]
        public decimal? Longitude { get; set; }
    }
}
