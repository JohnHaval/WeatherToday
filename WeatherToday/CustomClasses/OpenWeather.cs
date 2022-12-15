using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace WeatherToday.CustomClasses
{
    public class OpenWeather
    {
        [JsonProperty("base")]
        public string Base;
        public void GetWeatherToday()
        {
            WebClient web = new WebClient();
            
        }
    }
}
