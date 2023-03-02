using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelListingAPI.Models
{
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Password is limited from {2} to {1} characters", MinimumLength = 8)]
        public string Password { get; set; }
    }

    public class UserDTO : LoginUserDTO
    {
        [Required]
        public string FullName { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}
