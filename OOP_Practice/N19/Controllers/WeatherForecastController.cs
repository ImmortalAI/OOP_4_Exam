using Microsoft.AspNetCore.Mvc;
using N19.Managers;

namespace N19.Controllers
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
        private readonly IMyManager _manager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMyManager mm)
        {
            _logger = logger;
            _manager = mm;
        }

        [HttpPost]
        public IActionResult Post([FromBody] int a)
        {
            _manager.MyMethod();
            return Ok(a);
        }
    }
}
