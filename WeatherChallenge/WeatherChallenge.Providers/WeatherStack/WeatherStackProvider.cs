using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherChallenge.Providers.Models;

namespace WeatherChallenge.Providers.WeatherStack
{
    public class WeatherStackProvider : IWeatherStackProvider
    {
        private const string URL = "http://api.weatherstack.com/";
        private const string ACCESS_KEY = "2b5f6cb8d9d67c656d94dd73c14645b4";

        public async Task<bool> IsHighUV(string zipCode)
        {
            if (string.IsNullOrEmpty(zipCode))
            {
                throw new ArgumentException("Invalid zip code");
            }

            var weatherData = await GetWeatherData(zipCode);
            if (weatherData.Current != null)
            {
                if (weatherData.Current.UvIndex > 3)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> IsItRaining(string zipCode)
        {
            if (string.IsNullOrEmpty(zipCode))
            {
                throw new ArgumentException("Invalid zip code");
            }

            var weatherData = await GetWeatherData(zipCode);
            if (weatherData.Current != null)
            {
                if (weatherData.Current.WeatherDescriptions.Any(o => o.Contains("rain")))
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> IsItWindy(string zipCode)
        {
            if (string.IsNullOrEmpty(zipCode))
            {
                throw new ArgumentException("Invalid zip code");
            }

            var weatherData = await GetWeatherData(zipCode);
            if (weatherData.Current != null)
            {
                if (weatherData.Current.WindSpeed > 15)
                {
                    return true;
                }
            }

            return false;
        }

        private async Task<WeatherData> GetWeatherData(string zipCode)
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
                                throw new ArgumentException("No data was found for the zipcode submitted.");
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
