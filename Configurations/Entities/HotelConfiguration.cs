using HotelListingAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListingAPI.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Pearl Continental",
                    Rating = 4.5,
                    CountryId = 1,
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Fairmont Banff Springs",
                    Rating = 4.5,
                    CountryId = 3,
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Burj Khalifa",
                    Rating = 4.5,
                    CountryId = 2,
                }
            );
        }
    }
}
