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
            Timer.Interval = new TimeSpan(0, 1, 0);         
            Timer.IsEnabled = true;
        }
        WeatherData WeatherToday = new WeatherData();
        private void Timer_Tick(object sender, EventArgs e)
        {
            WeatherToday.GetWeather();
            IconState.Source = GetSourceIconState();
            LastTime.Content = DateTime.Now.ToString("t");
            Temperature.Content = WeatherToday.Temperature;
            TimeState.Content = WeatherToday.TimeState;
            WeatherState.Content = WeatherToday.WeatherState;
            FalloutState.Content = WeatherToday.FalloutState;
        }
        DispatcherTimer Timer = new DispatcherTimer();
        private BitmapImage GetSourceIconState()
        {
            BitmapImage imageState = new BitmapImage();
            imageState.BeginInit();
            imageState.UriSource = new Uri(WeatherToday.IconState);
            imageState.EndInit();
            return imageState;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Timer_Tick(sender, e);
        }

        private void AutoSync_Checked(object sender, RoutedEventArgs e)
        {
            Timer.IsEnabled = true;
        }

        private void AutoSync_Unchecked(object sender, RoutedEventArgs e)
        {
            Timer.IsEnabled = false;
        }

        private void GetToday_Click(object sender, RoutedEventArgs e)
        {
            Timer_Tick(sender, e);
        }

        private void GetRandom_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
