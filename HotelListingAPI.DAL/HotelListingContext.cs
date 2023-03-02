using HotelListingAPI.BLL.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.DAL
{
    public class HotelListingContext : IdentityDbContext<ApiUser>
    {
        public HotelListingContext(DbContextOptions<HotelListingContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new HotelConfiguration());

            modelBuilder.ApplyConfiguration(new CountryConfiguration());
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
