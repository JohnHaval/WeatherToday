using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;

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
