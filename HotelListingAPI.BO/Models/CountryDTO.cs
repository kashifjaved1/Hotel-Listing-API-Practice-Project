using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelListingAPI.Models
{
    public class CreateCountryDTO
    {
        [Required]
        public string Name { get; set; }
    }

    public class CountryDTO : CreateCountryDTO
    {
        public int Id { get; set; }
        public List<CreateHotelDTO> Hotels { get; set; }
    }

    public class UpdateCountryDTO : CreateCountryDTO
    {
        //
    }
}
