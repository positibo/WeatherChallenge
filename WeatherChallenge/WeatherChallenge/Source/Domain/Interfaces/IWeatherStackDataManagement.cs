using System.Threading.Tasks;
using WeatherChallenge.Source.Domain.Models;

namespace WeatherChallenge.Source.Domain.Interfaces
{
    public interface IWeatherStackDataManagement
    {
        Task<WeatherData> GetWeatherInfo(string zipCode);
    }
}
