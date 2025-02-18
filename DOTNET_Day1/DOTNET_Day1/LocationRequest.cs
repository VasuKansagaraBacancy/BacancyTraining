namespace DOTNET_Day1
{
    public class LocationRequest
    {
            public double Lat { get; set; }
            public double Long { get; set; }
    }
        public class LocationInfo
        {
            public String? Name;
            public String? ICAO;
            public double Lat;
            public double Long;
            public int? Elevation;
            public String? Country;
            public override string ToString()
            {
                return $"Name: {Name}, ICAO: {ICAO}, Lat: {Lat}, Long: {Long}, Elevation: {Elevation}, Country: {Country}";
            }
        
}
}
