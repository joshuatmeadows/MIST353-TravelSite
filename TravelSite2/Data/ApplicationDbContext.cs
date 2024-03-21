using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelSiteAPI.Entities;

namespace TravelSite2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TravelSiteAPI.Entities.Hotel> Hotel { get; set; } = default!;
    }
}
