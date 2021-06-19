using Newtonsoft.Json;

namespace WeatherChallenge.Providers.Models
{
    internal class Request
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
