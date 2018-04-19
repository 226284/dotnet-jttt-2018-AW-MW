using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Url
    {
        public string Address { get; set; }

        public Url() { }
        public Url(string address)
        {
            Address = address;
        }
    }
}
