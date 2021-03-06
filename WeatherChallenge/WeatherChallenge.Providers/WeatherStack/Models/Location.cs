using Newtonsoft.Json;

namespace WeatherChallenge.Providers.Models
{
    internal class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lon")]
        public string Lon { get; set; }

        [JsonProperty("timezone_id")]
        public string TimeZoneId { get; set; }

        [JsonProperty("localtime")]
        public string LocalTime { get; set; }

        [JsonProperty("localtime_epoch")]
        public string LocalTimeEpoch { get; set; }

        [JsonProperty("utc_offset")]
        public string UtcOffset { get; set; }
    }
}
