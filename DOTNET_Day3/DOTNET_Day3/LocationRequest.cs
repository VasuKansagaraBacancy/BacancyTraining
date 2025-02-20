namespace DOTNET_Day3
{
    public class LocationRequest: IOpenWeather
    {
        public String? Country { get; set; }
        public String? Name { get; set; }

        public LocationRequest GetWeather(float lon, float lat)
        {
            if (!OpenWeather.StationDictionary.TryGetClosestStation(lat, lon, out var stationInfo))
            {
                Console.WriteLine("Could not find a station.");
                return null;
            }
            var loaction = new LocationRequest
            {
                Name = stationInfo.Name,
                Country = stationInfo.Country
            };
            if (loaction.Name!="AHMADABAD") {
                return null;
            }
            return loaction;
        }
    }
}
