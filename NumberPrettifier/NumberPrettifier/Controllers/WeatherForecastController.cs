using Microsoft.AspNetCore.Mvc;
using Prettifier.Interfaces;

namespace NumberPrettifier.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IPrettifier _prettifier;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPrettifier prettifier)
        {
            _logger = logger;
            _prettifier = prettifier;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("pretty")]
        public string GetPrettyNumber(double number)
        {
            return _prettifier.Pretty(number);
        }
    }
}