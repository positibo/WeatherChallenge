using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherChallenge.Source.Domain.BusinessRules;
using WeatherChallenge.Source.Domain.Interfaces;
using WeatherChallenge.Source.Domain.Models;

namespace WeatherChallenge.Source.Infrastructure.WeatherStackDataHandling
{
    public class WeatherStackDataManagement : IWeatherStackDataManagement
    {
        private const string URL = "http://api.weatherstack.com/";
        private const string ACCESS_KEY = "2b5f6cb8d9d67c656d94dd73c14645b4";

        public async Task<WeatherData> GetWeatherInfo(string zipCode)
        {
            WeatherData weatherData = new WeatherData();

            try
            {
                var requestUri = $"{URL}current?access_key={ACCESS_KEY}&query={zipCode}";
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage responseMessage = await client.GetAsync(requestUri))
                    {
                        using (HttpContent content = responseMessage.Content)
                        {
                            var response = await content.ReadAsStringAsync();
                            if (response.Contains("404").Equals(true))
                            {
                                throw new NotFoundException();
                            }
                            else
                            {
                                weatherData = JsonConvert.DeserializeObject<WeatherData>(response);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return weatherData;
        }

    }
}
