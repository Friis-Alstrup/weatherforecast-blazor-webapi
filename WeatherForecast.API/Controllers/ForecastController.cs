using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Models;

namespace WeatherForecast.API.Controllers
{
    [ApiController]
    [Route("forecast")]
    public class ForecastController : Controller
    {
        [HttpGet("get/{city}")]
        public async Task<ActionResult<Root>> GetForecast(string city)
        {
            using HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("https://goweather.herokuapp.com/")
            };

            HttpResponseMessage message = await client.GetAsync($"weather/{city}");

            message.EnsureSuccessStatusCode();
            
            return await message.Content.ReadFromJsonAsync<Root>();
        }
    }
}
