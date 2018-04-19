using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Mail
    {
        public string Address { get; set; }

        public Mail() { }
        public Mail(string address)
        {
            Address = address;
        }
    }
}
