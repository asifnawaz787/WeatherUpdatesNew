using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherUpdates.Interfaces;
using WeatherUpdates.Models;

namespace WeatherUpdates.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherService _service;

        public HomeController(ILogger<HomeController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _service = weatherService;
        }

        public IActionResult Index()
        {
            ViewData["WeatherInfo"] = _service.GetWeatherByCountry();
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}