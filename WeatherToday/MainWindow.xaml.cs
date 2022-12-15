using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WeatherToday.CustomClasses;

namespace WeatherToday
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0,1,0);            
        }
        OpenWeather MainWeather = new OpenWeather();
        private void Timer_Tick(object sender, EventArgs e)
        {            
            MainWeather = new OpenWeather();
            MainWeather.GetWeatherToday();
            DisplayWeather();
        }
        DispatcherTimer Timer = new DispatcherTimer();
        private void DisplayWeather()//-------------------------------------Ввести русский язык. Прочитать TXT по установлению логики.
        {
            CurrentTime.Content = DateTime.Now.ToString("t");
            WeatherState.Content = MainWeather.weather.main;
            WeatherStateDetails.Content = MainWeather.weather.description;
            WeatherState.Content = MainWeather.weather.main;
        }
    }
}
