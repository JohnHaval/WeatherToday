using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace WeatherToday.CustomClasses
{
    public class WeatherData
    {
        public WeatherToday CurrentWeather { get; set; }
        public string IconState { get => $"http://openweathermap.org/img/wn/{CurrentWeather.weather[0].icon}@2x.png"; }
        public int Temperature { get; private set; }
        public string TimeState { get; private set; }
        public string WeatherState { get; private set; }
        public string FalloutState { get; private set; }
        public string DisplayPath { get; private set; }//Путь к GIF или картинкам
        private string GetTimeState(DateTime currentTime)
        {
            if (currentTime.Hour >= 0 && currentTime.Hour <= 5) return "Ночь";
            if (currentTime.Hour >= 6 && currentTime.Hour <= 11) return "Утро";
            if (currentTime.Hour >= 12 && currentTime.Hour <= 17) return "День";
            return "Вечер";
        }
        private string GetWeatherState()
        {
            string main = CurrentWeather.weather[0].main;
            if (main == "Clear")
            {
                DisplayPath = "/AnimStates/Clear.jpg";
                return "Ясно";
            }
            if (main == "Clouds")
            {
                DisplayPath = "/AnimStates/Clouds.jpg";
                return "Облачно";
            }
            if (main == "Snow" || main == "Rain" || main == "Drizzle" || main == "Thunderstorm")
            {
                return "Осадки";
            }
            DisplayPath = "/AnimStates/Clouds.jpg";
            return "Атмосферное явление";
        }
        private string GetFalloutState()
        {
            string description = CurrentWeather.weather[0].description;
            if (CheckMediumTemperature() && (description.ToLower().Contains("rain and snow") || description.ToLower().Contains("sleet")))
            {
                DisplayPath = "/AnimStates/RainAndSnow.gif";
                return "Дождь со снегом";
            }
            if (description.ToLower().Contains("snow") && description.ToLower().Contains("heavy"))
            {
                DisplayPath = "/AnimStates/HeavySnow.gif";
                return "Снежная буря";
            }
            if (description.ToLower().Contains("snow"))
            {
                DisplayPath = "/AnimStates/Snow.gif";
                return "Снежная метель";
            }
            if (description == "extreme rain" || description.ToLower().Contains("thunderstorm") || (description.Contains("shower") && description.Contains("rain")))
            {
                DisplayPath = "/AnimStates/ExtremeRain.gif";
                return "Дождевой ливень";
            }
            if (description.Contains("rain") || description.Contains("drizzle"))
            {
                DisplayPath = "/AnimStates/Rain.gif";
                return "Мелкий дождь";
            }
            return "Отсутствует";//Зависит от данных из OpenWeather
        }
        private bool CheckMediumTemperature()
        {
            Temperature = Convert.ToInt32(CurrentWeather.main.temp);
            if (Temperature >= -1 && Temperature <= 2) return true;
            return false;
        }
        /// <summary>
        /// Отвечает за полное формирование погоды последовательно. Результаты в свойствах! Используется текущие дата и время.
        /// </summary>
        /// <returns></returns>
        public void GetWeather()
        {
            GetWeatherToday();
            GetWeather(DateTime.Now);
        }
        /// <summary>
        /// Использовать для ГСЧ или самостоятельного формирования по дате.
        /// </summary>
        /// <param name="dateTime"></param>
        public void GetWeather(DateTime dateTime)
        {
            TimeState = GetTimeState(dateTime);
            WeatherState = GetWeatherState();
            FalloutState = GetFalloutState();
        }
        private void GetWeatherToday()
        {
            WebRequest request = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=Ryazan&appid=cced05e23a8fd9054a38c1de61d639ea");
            request.Method = "POST";            
            request.ContentType = "application/x-www-urlcoded";
            request.Timeout = 1500;
            WebResponse response = request.GetResponse();
            string answer = "";//Answer of request
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    answer = reader.ReadToEnd();
                }
            }
            response.Close();
            CurrentWeather = JsonConvert.DeserializeObject<WeatherToday>(answer);
        }
    }
}
