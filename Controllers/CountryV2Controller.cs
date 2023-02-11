using Microsoft.AspNetCore.Mvc;

namespace HotelListingAPI.Controllers
{
    //[Route("api/{v:apiversion}/Country")] // enable the client to access api using version in url.
    [Route("api/Country")] // using v1 country controller route on purpose.
    [ApiController]
    public class CountryV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hurray!!! You hit the \'Version 2\' of this API.");
        }
    }
}
