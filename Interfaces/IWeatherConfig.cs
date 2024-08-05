namespace WeatherUpdates.Interfaces
{
    public interface IWeatherConfig
    {
        string URl { get; set; }
        string Key { get; set; }
        string ZipCode { get; set; }
        string CountryCode { get; set; }
    }
}
