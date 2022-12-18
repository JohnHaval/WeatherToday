using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherToday;
using System;
using WeatherToday.CustomClasses;

namespace WeatherUnitTest
{
    [TestClass]
    public class WeatherFormTest
    {
        WeatherData _weatherData;
        DateTime currentTime = new DateTime();
        [TestMethod]
        public void __1CheckTimeState1()
        {
            RandomNumbersGenerator.GetRandomWeather();
            _weatherData = RandomNumbersGenerator.WeatherRandom;
            currentTime = new DateTime() + new TimeSpan(5, 0, 0);
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.TimeState == "Ночь");
        }
        [TestMethod]
        public void __2CheckTimeState2()
        {
            RandomNumbersGenerator.GetRandomWeather();
            _weatherData = RandomNumbersGenerator.WeatherRandom;
            currentTime = new DateTime() + new TimeSpan(6, 0, 0);
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.TimeState == "Утро");
        }
        [TestMethod]
        public void __3CheckTimeState3()
        {
            RandomNumbersGenerator.GetRandomWeather();
            _weatherData = RandomNumbersGenerator.WeatherRandom;
            currentTime = new DateTime() + new TimeSpan(12, 0, 0);
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.TimeState == "День");
        }
        [TestMethod]
        public void __4CheckTimeState4()
        {
            RandomNumbersGenerator.GetRandomWeather();
            _weatherData = RandomNumbersGenerator.WeatherRandom;
            currentTime = new DateTime() + new TimeSpan(22, 0, 0);
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.TimeState == "Вечер");
        }
        [TestMethod]
        public void __5CheckWeatherState1()
        {
            RandomNumbersGenerator.GetRandomWeather();
            _weatherData = RandomNumbersGenerator.WeatherRandom;
            _weatherData.CurrentWeather.weather[0].main = "Clear";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.WeatherState == "Ясно");
        }
        [TestMethod]
        public void __6CheckWeatherState2()
        {
            RandomNumbersGenerator.GetRandomWeather();
            _weatherData = RandomNumbersGenerator.WeatherRandom;
            _weatherData.CurrentWeather.weather[0].main = "Clouds";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.WeatherState == "Облачно");
        }
        [TestMethod]
        public void __7CheckWeatherState3()
        {
            RandomNumbersGenerator.GetRandomWeather();
            _weatherData = RandomNumbersGenerator.WeatherRandom;
            _weatherData.CurrentWeather.weather[0].main = "Mist";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.WeatherState == "Атмосферное явление");
        }
        [TestMethod]
        public void __8CheckWeatherState4()
        {
            RandomNumbersGenerator.GetRandomWeather();
            _weatherData = RandomNumbersGenerator.WeatherRandom;
            _weatherData.CurrentWeather.weather[0].main = "Rain";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.WeatherState == "Осадки");
            _weatherData.CurrentWeather.weather[0].main = "Snow";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.WeatherState == "Осадки");
            _weatherData.CurrentWeather.weather[0].main = "Drizzle";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.WeatherState == "Осадки");
            _weatherData.CurrentWeather.weather[0].main = "Thunderstorm";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.WeatherState == "Осадки");
        }
        [TestMethod]
        public void __9CheckFalloutState1()
        {
            RandomNumbersGenerator.GetRandomWeather();
            _weatherData = RandomNumbersGenerator.WeatherRandom;
            _weatherData.CurrentWeather.main.temp = 273.15;
            _weatherData.CurrentWeather.weather[0].description = "rain and snow";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.FalloutState == "Дождь со снегом");
            _weatherData.CurrentWeather.weather[0].description = "sleet";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.FalloutState == "Дождь со снегом");
            _weatherData.CurrentWeather.main.temp = 273.15 - 25;
            _weatherData.GetWeather(currentTime);
            Assert.IsFalse(_weatherData.FalloutState == "Дождь со снегом");
        }
        [TestMethod]
        public void _10CheckFalloutState2()
        {
            RandomNumbersGenerator.GetRandomWeather();
            _weatherData = RandomNumbersGenerator.WeatherRandom;
            _weatherData.CurrentWeather.weather[0].description = "heavy snow";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.FalloutState == "Снежная буря");
            _weatherData.CurrentWeather.weather[0].description = "snow";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.FalloutState == "Снежная метель");
        }
        [TestMethod]
        public void _11CheckFalloutState3()
        {
            RandomNumbersGenerator.GetRandomWeather();
            _weatherData = RandomNumbersGenerator.WeatherRandom;
            _weatherData.CurrentWeather.weather[0].description = "extreme rain";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.FalloutState == "Дождевой ливень");            
            _weatherData.CurrentWeather.weather[0].description = "thunderstorm";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.FalloutState == "Дождевой ливень");
            _weatherData.CurrentWeather.weather[0].description = "shower rain";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.FalloutState == "Дождевой ливень");
        }
        [TestMethod]
        public void _12CheckFalloutState4()
        {
            RandomNumbersGenerator.GetRandomWeather();
            _weatherData = RandomNumbersGenerator.WeatherRandom;
            _weatherData.CurrentWeather.weather[0].description = "drizzle";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.FalloutState == "Мелкий дождь");
            _weatherData.CurrentWeather.weather[0].description = "rain";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.FalloutState == "Мелкий дождь");
        }
        [TestMethod]
        public void _13CheckFalloutState5()
        {
            RandomNumbersGenerator.GetRandomWeather();
            _weatherData = RandomNumbersGenerator.WeatherRandom;
            _weatherData.CurrentWeather.weather[0].description = "clear sky";
            _weatherData.GetWeather(currentTime);
            Assert.IsTrue(_weatherData.FalloutState == "Отсутствует");
        }        
    }
}
