using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HotelListingAPI.DAL;

namespace HotelListingAPI.BLL.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    Id = 1,
                    Name = "Pakistan",
                },
                new Country
                {
                    Id = 2,
                    Name = "Dubai",
                },
                new Country
                {
                    Id = 3,
                    Name = "Canada",
                }
            );
        }
    }
}
