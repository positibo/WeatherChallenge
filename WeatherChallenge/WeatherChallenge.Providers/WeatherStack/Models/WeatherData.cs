using Newtonsoft.Json;

namespace WeatherChallenge.Providers.Models
{
    internal class WeatherData
    {
        [JsonProperty("request")]
        public Request Request { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("current")]
        public Current Current { get; set; }

    }
}
