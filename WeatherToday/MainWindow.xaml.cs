using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WeatherToday.CustomClasses;
using WpfAnimatedGif;

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
            IconState.Source = GetIconState();
            GetDisplayState(false);
            LastTime.Content = DateTime.Now.ToString("t");
            Temperature.Content = WeatherToday.Temperature;
            TimeState.Content = WeatherToday.TimeState;
            WeatherState.Content = WeatherToday.WeatherState;
            FalloutState.Content = WeatherToday.FalloutState;
        }
        DispatcherTimer Timer = new DispatcherTimer();
        private BitmapImage GetIconState()
        {
            BitmapImage imageState = new BitmapImage();
            imageState.BeginInit();
            imageState.UriSource = new Uri(WeatherToday.IconState);
            imageState.EndInit();
            ImageBehavior.SetAnimatedSource(DisplayState, imageState);
            return imageState;
        }
        private void GetDisplayState(bool isRandom)
        {
            BitmapImage imageState = new BitmapImage();
            imageState.BeginInit();
            if (!isRandom) imageState.UriSource = new Uri(WeatherToday.DisplayPath, UriKind.RelativeOrAbsolute);
            else imageState.UriSource = new Uri(RandomNumbersGenerator.WeatherRandom.DisplayPath, UriKind.RelativeOrAbsolute);
            imageState.EndInit();
            ImageBehavior.SetAnimatedSource(DisplayState, imageState);
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
            RandomNumbersGenerator.GetRandomWeather();
            IconState.Source = GetIconState();
            GetDisplayState(true);
            LastTime.Content = RandomNumbersGenerator.RandomTime.ToString("t");
            Temperature.Content = RandomNumbersGenerator.WeatherRandom.Temperature;
            TimeState.Content = RandomNumbersGenerator.WeatherRandom.TimeState;
            WeatherState.Content = RandomNumbersGenerator.WeatherRandom.WeatherState;
            FalloutState.Content = RandomNumbersGenerator.WeatherRandom.FalloutState;
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программа позволяет выполнять следующее:\n" +
                "- отображать информацию о погоде и времени суток в Рязанской области;\n" +
                "- автосинхронизация получения погоды позволяет получить погоду на текущий момент каждую минуту;\n" +
                "- состояние погоды отображается на картинках или GIF", "Справка", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчиком программы является студент группы ИСП-41 Лопаткин Сергей\n" +
                "GitHub.Name=JohnHaval(Ранее - HaproBishop)", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
