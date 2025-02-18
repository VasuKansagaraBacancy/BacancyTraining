using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Day1.Controllers
{

    [Route("ap1/[controller]")]
    [ApiController]
    public class LocationAPI : Controller
    {
        [HttpPost]
            public IActionResult WeatherPost([FromBody] LocationRequest request)
            {
                if (!OpenWeather.StationDictionary.TryGetClosestStation(request.Lat, request.Long, out var stationInfo))
                {
                    Console.WriteLine("Could not find a station.");
                    return NotFound("ERROR");
                }

                var weather = new LocationInfo
                {
                    Name = stationInfo.Name,
                    ICAO = stationInfo.ICAO,
                    Lat = stationInfo.Latitude,
                    Long = stationInfo.Longitude,
                    Elevation = stationInfo.Elevation,
                    Country = stationInfo.Country,
                };

                return Ok(weather.ToString());
            }

        }
    
}
