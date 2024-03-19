using System.ComponentModel.DataAnnotations;
namespace TravelSiteAPI.Entities
{
    public class Room
    {
      [Key]
      public int RoomID { get; set; }
        public int HotelID { get; set; }
        public int NumBeds { get; set; }
        public string RoomType { get; set; }
        public int numberNum { get; set; }
        public int floor { get; set; }
    }
}
