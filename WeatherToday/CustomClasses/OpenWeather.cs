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
    public class OpenWeather
    {
        public OpenWeather CurrentWeather { get; set; }
        [JsonProperty("base")]
        public string Base;
        public main main;
        public weather weather;
        public void GetWeatherToday()
        {
            WebRequest request = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=Ryazan&appid=cced05e23a8fd9054a38c1de61d639ea");
            request.Method = "POST";
            request.ContentType = "application/x-www-urlcoded";
            WebResponse response = request.GetResponse();
            string answer = "";//Answer of request
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    answer = reader.ReadToEnd();
                }
            }
            response.Close();//? Is Need ?-------------Check this later
            CurrentWeather = JsonConvert.DeserializeObject<OpenWeather>(answer);
        }
    }
}
