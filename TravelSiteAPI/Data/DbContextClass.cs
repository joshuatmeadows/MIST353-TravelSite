using Microsoft.EntityFrameworkCore;
using TravelSiteAPI.Entities;

namespace TravelSiteAPI.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options)
            : base(options)
        {
        }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelRating> HotelRating { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomAvailiability> RoomAvailiability { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartLine> CartLines { get; set; }

    }
}
