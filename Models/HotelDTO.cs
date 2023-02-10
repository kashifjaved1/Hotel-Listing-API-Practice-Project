using System.ComponentModel.DataAnnotations;

namespace HotelListingAPI.Models
{
    public class CreateHotelDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 5)]
        public string Rating { get; set; }
    }
}
