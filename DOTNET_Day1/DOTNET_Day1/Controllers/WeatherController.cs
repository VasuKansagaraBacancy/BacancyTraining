using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Day1.Controllers
{
    [ApiController]
    [Route("[controller]")]   
    public class OpenWeatherController : ControllerBase
    {
        [HttpGet("{latitude}/{longitude}")]
        public IActionResult Get(float longitude, float latitude)
        {
            if (!OpenWeather.StationDictionary.TryGetClosestStation(latitude, longitude, out var stationInfo))
            {
                return BadRequest("Could not find a station.");
            }
            string text = $"STATION NAME : {stationInfo.Name}\nCOUNTRY : {stationInfo.Country}\n";

            var loaction = new LocationRequest
            {
                Name = stationInfo.Name,
                Country = stationInfo.Country
            };
            return Ok(loaction);
        }
    }
}