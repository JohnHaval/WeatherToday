using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherToday.CustomClasses;

namespace WeatherToday
{
    public static class RandomNumbersGenerator
    {
        static WeatherData WeatherRandom = new WeatherData(); 
        private static string[] WeatherStates { get => GetWeatherStates(); }     
        private static string[] GetWeatherStates()
        {
            var weatherStates = new string[3];
            weatherStates.SetValue("Clear", 0);
            weatherStates.SetValue("Clouds", 1);
            weatherStates.SetValue("Other", 2);//Может быть любое значение для алгоритма вычисления
            return weatherStates;
        }
        private static string[] FalloutStates { get => GetFalloutStates(); }
        private static string[] GetFalloutStates()
        {
            var falloutStates = new string[5];
            falloutStates.SetValue("heavy snow", 0);
            falloutStates.SetValue("Snow", 1);
            falloutStates.SetValue("thunderstorm", 2);
            falloutStates.SetValue("rain", 3);
            falloutStates.SetValue("rain and snow", 4);            
            return falloutStates;
        }
        public static int GetRandom(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
        public static void GetRandomWeather()
        {
            var time = (DateTime)new TimeSpan(0, GetRandom(0, 24), GetRandom(0, 60));
            
        }
        private static void IntoWeatherRandom()
        {
            int temp = GetRandom(-30, 30);
            WeatherRandom.CurrentWeather.main.temp = temp;
            string rndWeatherState = WeatherStates[GetRandom(0, 3)];
            WeatherRandom.CurrentWeather.weather[0].main = WeatherStates[GetRandom(0, 3)];
            if (rndWeatherState == "Other")
            {
                string rndFalloutState = FalloutStates[4];//"rain and snow"//Используется для удовлетворения правильности рандома
                if (temp < -1 && temp > 2)
                    WeatherRandom.CurrentWeather.weather[0].description =
                        rndFalloutState = FalloutStates[GetRandom(0, 4)];
            }
            else WeatherRandom.CurrentWeather.weather[0].description = "Отсутствует";
        }
    }
}
