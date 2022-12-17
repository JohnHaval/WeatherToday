using Newtonsoft.Json;

namespace WeatherToday.CustomClasses
{
    public class WeatherToday
    {
        [JsonProperty("base")]
        public string Base;
        public main main;
        public weather[] weather;
    }
}
