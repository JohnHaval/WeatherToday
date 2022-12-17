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
        public static WeatherData WeatherRandom = new WeatherData(); 
        public static DateTime RandomTime { get; private set; }
        private static string[] WeatherStates { get => GetWeatherStates(); }     
        private static string[] GetWeatherStates()
        {
            var weatherStates = new string[7];
            weatherStates.SetValue("Clear", 0);
            weatherStates.SetValue("Clouds", 1);
            weatherStates.SetValue("Rain", 2);
            weatherStates.SetValue("Snow", 3);
            weatherStates.SetValue("Drizzle", 4);
            weatherStates.SetValue("Thunderstorm", 5);
            weatherStates.SetValue("Other", 6);//Может быть любое значение для алгоритма вычисления
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
        /// <summary>
        /// Производит формирование всех результативных значений в WeatherRandom свойстве. Основа работы - WeatherData. Смотреть там работу.
        /// </summary>
        public static void GetRandomWeather()
        {
            RandomTime = new DateTime() + new TimeSpan(GetRandom(0, 24), GetRandom(0, 60), 0);
            IntoWeatherRandom();
            WeatherRandom.GetWeather(RandomTime);
        }
        /// <summary>
        /// Производит рандомное занесение основной (необходимой) информации для работы формирования значений в классе WeatherData.
        /// </summary>
        private static void IntoWeatherRandom()
        {
            int temp = GetRandom(-30, 30) + Convert.ToInt32(273.15);//Необходимо добавить значение по Клельвину для правильности отображения (Свойство минусует значение на получении. ООП)
            WeatherRandom.CurrentWeather = new CustomClasses.WeatherToday();
            WeatherRandom.CurrentWeather.main = new main();
            WeatherRandom.CurrentWeather.main.temp = temp;
            temp = Convert.ToInt32(WeatherRandom.CurrentWeather.main.temp);
            string rndWeatherState = WeatherStates[GetRandom(0, 7)];            
            WeatherRandom.CurrentWeather.weather = new weather[1];
            WeatherRandom.CurrentWeather.weather.SetValue(new weather(), 0);
            WeatherRandom.CurrentWeather.weather[0].main = rndWeatherState;
            if (rndWeatherState != "Other" && rndWeatherState != "Clear" && rndWeatherState != "Clouds")
            {
                string rndFalloutState = FalloutStates[4];//"rain and snow"//Используется для удовлетворения правильности рандома
                if (temp < -1 || temp > 2)
                {
                    if (rndWeatherState.ToLower().Contains("snow"))
                    {
                        if (RandomTime.Hour >= 0 && RandomTime.Hour <= 5)
                            WeatherRandom.CurrentWeather.weather[0].icon = "13n";
                        else WeatherRandom.CurrentWeather.weather[0].icon = "13d";
                        rndFalloutState = FalloutStates[GetRandom(0, 2)];
                    }
                    else
                    {
                        if (RandomTime.Hour >= 0 && RandomTime.Hour <= 5)
                            WeatherRandom.CurrentWeather.weather[0].icon = "10n";
                        else WeatherRandom.CurrentWeather.weather[0].icon = "10d";
                        rndFalloutState = FalloutStates[GetRandom(2, 4)];
                    }
                }
                else
                {
                    if (RandomTime.Hour >= 0 && RandomTime.Hour <= 5)
                        WeatherRandom.CurrentWeather.weather[0].icon = "09n";
                    else WeatherRandom.CurrentWeather.weather[0].icon = "09d";
                }
                WeatherRandom.CurrentWeather.weather[0].description = rndFalloutState;
            }
            else
            {
                if (rndWeatherState == "Clear")
                {
                    if (RandomTime.Hour >= 0 && RandomTime.Hour <= 5)
                        WeatherRandom.CurrentWeather.weather[0].icon = "01n";
                    else WeatherRandom.CurrentWeather.weather[0].icon = "01d";
                }
                if (rndWeatherState == "Clouds")
                {
                    if (RandomTime.Hour >= 0 && RandomTime.Hour <= 5)
                        WeatherRandom.CurrentWeather.weather[0].icon = "04n";
                    else WeatherRandom.CurrentWeather.weather[0].icon = "04d";
                }
                if (rndWeatherState == "Other")
                {
                    if (RandomTime.Hour >= 0 && RandomTime.Hour <= 5)
                        WeatherRandom.CurrentWeather.weather[0].icon = "50n";
                    else WeatherRandom.CurrentWeather.weather[0].icon = "50d";
                }
                WeatherRandom.CurrentWeather.weather[0].description = "Отсутствует";
            }
        }
    }
}
