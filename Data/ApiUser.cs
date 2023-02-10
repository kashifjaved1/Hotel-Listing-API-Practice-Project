using Microsoft.AspNetCore.Identity;

namespace HotelListingAPI.Data
{
    public class ApiUser : IdentityUser
    {
        public string FullName { get; set; }        
    }
}
