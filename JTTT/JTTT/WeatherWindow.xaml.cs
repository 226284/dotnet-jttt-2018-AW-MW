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
using System.Windows.Shapes;

namespace JTTT
{
    /// <summary>
    /// Logika interakcji dla klasy WeatherWindow.xaml
    /// </summary>
    public partial class WeatherWindow : Window
    {
        public WeatherWindow()
        {
            InitializeComponent();
        }

        private void CheckWeather(object sender, RoutedEventArgs e)
        {
            var api = new WeatherApi();
            City city = new City();
            city.Name = CityBox.Text;
            Weather.Text = "Temperatura: " + api.GetTemperature(city).toCelsius() + "\n";
            WeatherIcon.Source = api.GetIcon();
        }
    }
}
