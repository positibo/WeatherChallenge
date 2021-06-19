using System;
using System.Threading.Tasks;
using WeatherChallenge.Providers.WeatherStack;

namespace WeatherChallenge.ConsoleApp
{
    class Program
    {
        private static readonly IWeatherStackProvider provider = new WeatherStackProvider();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Weather Code Challenge\r");
            Console.WriteLine("------------------------\n");

            // Ask the user to input zip code.
            Console.WriteLine("Type a zip code, and then press Enter");
            var zipCode = Console.ReadLine();

            await CanUserGoOutside(zipCode);
            await CanUserWearSunscreen(zipCode);
            await CanUserFlyKite(zipCode);

            // Wait for the user to respond before closing.
            Console.Write("Press any key to close the console app...");
            Console.ReadKey();
        }

        static async Task CanUserGoOutside(string zipCode)
        {
            bool isRaining = await provider.IsItRaining(zipCode);
            Console.WriteLine(isRaining ? "No" : "Yes");
        }

        static async Task CanUserWearSunscreen(string zipCode)
        {
            bool isHighUV = await provider.IsHighUV(zipCode);
            Console.WriteLine(isHighUV ? "Yes" : "No");
        }

        static async Task CanUserFlyKite(string zipCode)
        {
            bool canUserFlyKite = false;
            if (!await provider.IsItRaining(zipCode) && await provider.IsItWindy(zipCode))
                canUserFlyKite = true;

            Console.WriteLine(canUserFlyKite ? "Yes" : "No");
        }
    }
}
