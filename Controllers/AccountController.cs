using AutoMapper;
using HotelListingAPI.Data;
using HotelListingAPI.Models;
using HotelListingAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace HotelListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<ApiUser> userManager, IMapper mapper, IAuthManager authManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authManager = authManager;
        }

        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.FullName;
                var result = await _userManager.CreateAsync(user);
                await _userManager.AddToRolesAsync(user, userDTO.Roles);
                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                if (!await _authManager.ValidateUser(loginUserDTO)) return Unauthorized();
                return Accepted(new
                {
                    token = await _authManager.CreateToken()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
