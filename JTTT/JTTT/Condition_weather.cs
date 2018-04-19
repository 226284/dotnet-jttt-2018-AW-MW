using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace JTTT
{
    class Condition_weather : Condition
    {
        public Condition_weather()
        {

        }

        public async override Task<bool> Check(Parameters parameters)
        {
            var api = new WeatherApi();
            City city = new City();
            city.Name = parameters.City.Name;

            // zapis do pliku
            if (api.GetTemperature(city).CelsiusVal() < parameters.Temperature.Value) { return false; }
            parameters.Description = "Miasto: " + parameters.City.Name + ", Temperatura: " + api.GetTemperature(city).toCelsius() + "\n";
            api.SaveIcon(parameters.Id);

            return true;
        }

        public override string ToString()
        {
            return "Check weather";
        }
    }
}

