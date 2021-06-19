using System;
using System.Linq;
using System.Threading.Tasks;
using WeatherChallenge.Infrastructure;

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
            var weather = new Weather();

            //  Yes if it’s not raining, no if it’s raining
            var isRaining = await weather.IsItRaining(zipCode);
            var canUserShouldGoOutside = !isRaining;

            //  Is UV index above 3 then YES
            var canUserShouldWearSunscreen = await weather.IsHighUV(zipCode);

            //  Yes if not raining and wind speed over 15
            var canUserFlyKite = false;
            if (!isRaining && await weather.IsItWindy(zipCode))
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
