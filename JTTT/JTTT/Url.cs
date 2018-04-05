using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Url
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string address { get; set; }
        public Url(string _address)
        {
            address = _address;
        }
    }
}
