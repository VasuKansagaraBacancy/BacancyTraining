namespace DOTNET_Day3
{
    public interface IOpenWeather
    {
        public LocationRequest GetWeather(float lon, float lat);
    }
}
