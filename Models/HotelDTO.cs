using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace HotelListingAPI.Models
{
    public class CreateHotelDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }
        [Required]
        public int CountryId { get; set; }
    }

    public class HotelDTO : CreateHotelDTO
    {
        public int Id { get; set; }
        public CountryDTO Country { get; set; }
    }

    public class UpdateHotelDTO : CreateHotelDTO
    {
        //
    }
}
