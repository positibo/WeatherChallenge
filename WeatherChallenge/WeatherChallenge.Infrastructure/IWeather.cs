using System.Threading.Tasks;
using WeatherChallenge.Infrastructure.Dto;

namespace WeatherChallenge.Infrastructure
{
    public interface IWeather
    {
        Task<WeatherData> GetWeatherInfo(string zipCode);
    }
}
