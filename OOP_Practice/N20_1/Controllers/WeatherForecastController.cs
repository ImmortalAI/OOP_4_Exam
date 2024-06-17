using Microsoft.AspNetCore.Mvc;
using N20_1.Models;

namespace N20_1.Controllers
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
        private readonly HttpClient httpClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5001");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await httpClient.GetFromJsonAsync<MyModel[]>("/WeatherForecast");
            return Ok(res);
        }
    }
}
