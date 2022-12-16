using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherToday.CustomClasses
{
    public class main
    {
        private double _temp;
        public double temp { get => _temp; set => _temp = value - 273.15; }
    }
}
