namespace JTTT
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using J = Newtonsoft.Json.JsonPropertyAttribute;
    using R = Newtonsoft.Json.Required;
    using N = Newtonsoft.Json.NullValueHandling;

    public partial class WeatherValues
    {
        [J("coord")] public Coord Coord { get; set; }
        [J("weather")] public Weather[] Weather { get; set; }
        [J("base")] public string Base { get; set; }
        [J("main")] public Main Main { get; set; }
        [J("visibility")] public long Visibility { get; set; }
        [J("wind")] public Wind Wind { get; set; }
        [J("clouds")] public Clouds Clouds { get; set; }
        [J("dt")] public long Dt { get; set; }
        [J("sys")] public Sys Sys { get; set; }
        [J("id")] public long Id { get; set; }
        [J("name")] public string Name { get; set; }
        [J("cod")] public long Cod { get; set; }
    }

    public partial class Clouds
    {
        [J("all")] public long All { get; set; }
    }

    public partial class Coord
    {
        [J("lon")] public double Lon { get; set; }
        [J("lat")] public double Lat { get; set; }
    }

    public partial class Main
    {
        [J("temp")] public double Temp { get; set; }
        [J("pressure")] public long Pressure { get; set; }
        [J("humidity")] public long Humidity { get; set; }
        [J("temp_min")] public double TempMin { get; set; }
        [J("temp_max")] public double TempMax { get; set; }
    }

    public partial class Sys
    {
        [J("type")] public long Type { get; set; }
        [J("id")] public long Id { get; set; }
        [J("message")] public double Message { get; set; }
        [J("country")] public string Country { get; set; }
        [J("sunrise")] public long Sunrise { get; set; }
        [J("sunset")] public long Sunset { get; set; }
    }

    public partial class Weather
    {
        [J("id")] public long Id { get; set; }
        [J("main")] public string Main { get; set; }
        [J("description")] public string Description { get; set; }
        [J("icon")] public string Icon { get; set; }
    }

    public partial class Wind
    {
        [J("speed")] public double Speed { get; set; }
        [J("deg")] public long Deg { get; set; }
    }

    public partial class WeatherValues
    {
        public static WeatherValues FromJson(string json) => JsonConvert.DeserializeObject<WeatherValues>(json);
    }
}
