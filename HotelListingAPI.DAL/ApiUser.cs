using Microsoft.AspNetCore.Identity;

namespace HotelListingAPI.DAL
{
    public class ApiUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
