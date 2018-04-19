using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace JTTT
{
    class WeatherApi
    {
        private string baseurl = "http://api.openweathermap.org/data/2.5/weather";
        private string key = "97c41ac0b7b5c9bad02af6b593f12628";

        private WeatherValues _values;

        public WeatherApi()
        {
            baseurl += "?" + "appid=" + key;
        }

        public WeatherApi(City city)
        {
            baseurl += "?" + "appid = " + key;
            var response = GetResponse("&q=" + city.Name);
            _values = WeatherValues.FromJson(response);
        }

        private string GetResponse(string _params)
        {
            WebClient wc = new WebClient();
            try
            {
                string response = wc.DownloadString(baseurl + _params);

                return response;
            }
            catch (WebException ex)
            {
                var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                Debug.WriteLine(resp);
                return null;
            }
        }

        public Temperature GetTemperature()
        {

            Temperature temp = new Temperature();

            temp.Value = _values.Main.Temp;

            return temp;
        }

        public Temperature GetTemperature(City city)
        {
            var response = GetResponse("&q=" + city.Name);
            _values = WeatherValues.FromJson(response);
            return GetTemperature();
        }

        public BitmapImage GetIcon()
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("http://openweathermap.org/img/w/" + _values.Weather[0].Icon + ".png", UriKind.Absolute);
            bitmap.EndInit();
            return bitmap;
        }

        public void SaveIcon(int id)
        {
            string path = @"tmp/img" + id + ".jpg";
            using (var client = new WebClient())
            {
                client.DownloadFile("http://openweathermap.org/img/w/" + _values.Weather[0].Icon + ".png", path);
            }
        }

    }
}
