using IOTHubBlazor.Shared;
using Microsoft.AspNetCore.Mvc;

namespace IOTHubBlazor.Server.Controllers
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
        private readonly HttpClient _client;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory client)
        {
            _logger = logger;
            _client = client.CreateClient("httpClient");
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            try
            {
                Console.WriteLine("ClientConnect");
                _client.BaseAddress = new Uri("http://localhost:3000");
                Console.WriteLine(_client.BaseAddress);
                var value = await _client.GetAsync("/");
                Console.WriteLine("ClientConnectEnd");

                Console.WriteLine("STATUS", value.StatusCode.ToString());
                Console.WriteLine("VALUE", await value.Content.ReadAsStringAsync());
                /*
                
                if (!value.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(value.StatusCode.ToString());
                }
                else
                {
                    var text = await value.Content.ReadAsStringAsync();
                    Console.WriteLine(text);
                }
                */
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
            

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}