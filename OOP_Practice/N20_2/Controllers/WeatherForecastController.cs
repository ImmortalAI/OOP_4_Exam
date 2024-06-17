using Microsoft.AspNetCore.Mvc;
using N20_1.Models;

namespace N20_2.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            MyModel[] models = new MyModel[3] {
                new MyModel { Id = 1, Name = "1_1", Description = "1_1_1" },
                new MyModel { Id = 2, Name = "2_2", Description = "2_2_2" },
                new MyModel { Id = 3, Name = "3_3", Description = "3_3_3" } };
            return Ok(models);
        }
    }
}
