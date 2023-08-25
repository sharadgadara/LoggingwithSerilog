using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LoggingwithSerilog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[] {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                int i = 0;

                _logger.LogDebug("Start : Inside Get Weather.");
                var response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();

                if (5/i == 5)
                {
                   
                }

                _logger.LogDebug($"The response for the get weather forecast is {JsonConvert.SerializeObject(response)}");

                return response;
            }
            catch (Exception)
            {
                throw new Exception("Faild to retrive Data In Get Weather");
            }
        }
    }
}