using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Mail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Mail(string address)
        {
            Address = address;
        }
    }
}
