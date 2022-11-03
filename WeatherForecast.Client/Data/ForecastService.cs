using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WeatherForecast.Models;

namespace WeatherForecast.Client.Data
{
    public class ForecastService
    {

        private HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7167")
        };

        public async Task<Root> GetForecast(string city)
        {
            HttpResponseMessage message = await client.GetAsync($"/forecast/get/{city}");
            message.EnsureSuccessStatusCode();

            var response = await message.Content.ReadAsStringAsync();
            Root? forecast = JsonSerializer.Deserialize<Root>(response);

            return forecast;
        }
    }
}