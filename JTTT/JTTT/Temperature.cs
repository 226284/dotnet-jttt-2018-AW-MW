using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Temperature
    {
        //public int Id { get; set; }
        public double Value { get; set; }

        public string toCelsius()
        {
            return (Value - 273.15).ToString() + "°C";
        }
    }
}
