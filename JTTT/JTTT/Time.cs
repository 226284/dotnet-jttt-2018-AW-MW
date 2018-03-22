using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Time
    {
        public string time { get; set; }

        public Time()
        {
            time = DateTime.Now.ToString();
            //Console.WriteLine(time);
        }
    }
}
