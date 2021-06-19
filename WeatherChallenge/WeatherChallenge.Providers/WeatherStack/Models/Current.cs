using Newtonsoft.Json;

namespace WeatherChallenge.Providers.Models
{
    internal class Current
    {
        [JsonProperty("observation_time")]
        public string ObservationTime { get; set; }

        [JsonProperty("temperature")]
        public int Temperature { get; set; }

        [JsonProperty("weather_code")]
        public long WeatherCode { get; set; }

        [JsonProperty("weather_icons")]
        public string[] WeatherIcons { get; set; }

        [JsonProperty("weather_descriptions")]
        public string[] WeatherDescriptions { get; set; }

        [JsonProperty("wind_speed")]
        public int WindSpeed { get; set; }

        [JsonProperty("wind_degree")]
        public long WindDegree { get; set; }

        [JsonProperty("wind_dir")]
        public string WindDir { get; set; }

        [JsonProperty("pressure")]
        public long Pressure { get; set; }

        [JsonProperty("precip")]
        public long Precip { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("cloudcover")]
        public string CloudCover { get; set; }

        [JsonProperty("feelslike")]
        public long FeelsLike { get; set; }

        [JsonProperty("uv_index")]
        public int UvIndex { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }
    }
}
