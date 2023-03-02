using HotelListingAPI.Models;
using System.Threading.Tasks;

namespace HotelListingAPI.Services
{
    public interface IAuthManager
    {
        public Task<string> CreateToken();
        Task<bool> ValidateUser(LoginUserDTO loginUserDTO);
    }
}
