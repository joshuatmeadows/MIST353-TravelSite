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
    }
}
