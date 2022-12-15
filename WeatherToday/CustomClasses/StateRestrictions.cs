using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherToday.CustomClasses
{
    public static class StateRestrictions
    {
        public static string TimeState { get; set; }
        public static string GetTimeState(DateTime currentTime)
        {
            if (currentTime.Hour >= 0 && currentTime.Hour <= 5) TimeState = "Ночь";
            if (currentTime.Hour >= 6 && currentTime.Hour <= 11) TimeState = "Утро";
            if (currentTime.Hour >= 12 && currentTime.Hour <= 17) TimeState = "День";
            if (currentTime.Hour >= 18 && currentTime.Hour <= 23) TimeState = "Вечер";
            return TimeState;
        }
        //-------------------------------------------------------------------------Дописать
        public static string GetIntensivityState(string currentWeatherState)
        {
            return TimeState;
        }
    }
}
