using Microsoft.AspNetCore.Mvc;

namespace N18.Controllers
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
        public IActionResult Get([FromQuery] int a)
        {
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Post([FromBody] int a)
        {
            return Ok(a);
        }
        [HttpPut]
        public IActionResult Put([FromQuery] int a)
        {
            return Ok(a);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int a)
        {
            return Ok(a);
        }
    }
}
