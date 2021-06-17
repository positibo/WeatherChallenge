using System;
using System.Linq;
using System.Threading.Tasks;
using WeatherChallenge.Source.Infrastructure.WeatherStackDataHandling;

namespace WeatherChallenge.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Weather Code Challenge\r");
            Console.WriteLine("------------------------\n");

            // Ask the user to input zip code.
            Console.WriteLine("Type a zip code, and then press Enter");
            var zipCode = Console.ReadLine();
            var dataManagement = new WeatherStackDataManagement();
            var weatherInfo = await dataManagement.GetWeatherInfo(zipCode);

            //  Yes if it’s not raining, no if it’s raining
            var canUserShouldGoOutside = false;
            if (!weatherInfo.Current.WeatherDescriptions.Any(o => o.Contains("rain")))
                canUserShouldGoOutside = true;

            //  Is UV index above 3 then YES
            var canUserShouldWearSunscreen = false;
            if (weatherInfo.Current.UvIndex > 3)
                canUserShouldWearSunscreen = true;

            //  Yes if not raining and wind speed over 15
            var canUserFlyKite = false;
            if (!weatherInfo.Current.WeatherDescriptions.Any(o => o.Contains("rain")) && weatherInfo.Current.WindSpeed > 15)
                canUserFlyKite = true;

            Console.WriteLine("Should I go outside?");
            if(canUserShouldGoOutside)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

            Console.WriteLine("Should I wear sunscreen?");
            if (canUserShouldWearSunscreen)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

            Console.WriteLine("Can I fly my kite?");
            if (canUserFlyKite)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

            // Wait for the user to respond before closing.
            Console.Write("Press any key to close the console app...");
            Console.ReadKey();
        }
    }
}
