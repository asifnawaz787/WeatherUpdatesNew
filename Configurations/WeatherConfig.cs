using WeatherUpdates.Interfaces;

namespace WeatherUpdates.Configurations
{
    public class WeatherConfig : IWeatherConfig
    {
        public string URl { get; set; }

        public string Key { get; set; }

        public string ZipCode { get; set; }

        public string CountryCode { get; set; }
    }
}
