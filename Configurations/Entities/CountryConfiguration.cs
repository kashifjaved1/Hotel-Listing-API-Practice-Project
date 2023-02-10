using HotelListingAPI.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Configurations.Entities
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
