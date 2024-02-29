using TravelSite2API.Entities;
using Microsoft.EntityFrameworkCore;

namespace TravelSite2API.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        { }
        public DbSet<Hotel> Hotel { get; set; }
    }
}
