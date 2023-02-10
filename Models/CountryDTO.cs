using HotelListingAPI.Data;
using System.Collections;
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
        public List<Hotel> Hotels { get; set; }
    }
}
