using System.Threading.Tasks;

namespace WeatherChallenge.Providers.WeatherStack
{
    public interface IWeatherStackProvider
    {
        Task<bool> IsItRaining(string zipCode);
        Task<bool> IsHighUV(string zipCode);
        Task<bool> IsItWindy(string zipCode);
    }
}
