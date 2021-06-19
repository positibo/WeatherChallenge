using System.Threading.Tasks;

namespace WeatherChallenge.Infrastructure
{
    public interface IWeather
    {
        Task<bool> IsItRaining(string zipCode);

        Task<bool> IsItWindy(string zipCode);

        Task<bool> IsHighUV(string zipCode);
    }
}
