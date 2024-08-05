using WeatherUpdates.Interfaces;

namespace WeatherUpdates.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IWeatherConfig _weatherConfig;
        public WeatherService(HttpClient http,IWeatherConfig weatherConfig)
        {
            _httpClient = http;
            _weatherConfig = weatherConfig;
        }
        public   string GetWeatherByCountry()
        {
            var response =  _httpClient.GetAsync(new Uri(_weatherConfig.URl.Replace("{zipCode}", _weatherConfig.ZipCode).Replace("{countryCode}", _weatherConfig.CountryCode).Replace("{apiKey}", _weatherConfig.Key))).Result; 
            var result =  response.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}
