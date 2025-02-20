using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Day3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenWeatherController : ControllerBase
    {
        private readonly IOpenWeather _weather;
        public OpenWeatherController(IOpenWeather _weather)
        {
            this._weather = _weather;
        }
        [HttpGet("OpenWeather/{latitude}/{longitude}")]
        public IActionResult Get(float longitude, float latitude)
        {
            LocationRequest obj = _weather.GetWeather(longitude, latitude);

            if (obj == null)
            {
                return BadRequest("ENTER VALID COORDINATES");
            }
            return Ok(obj);
        }
    }

}
