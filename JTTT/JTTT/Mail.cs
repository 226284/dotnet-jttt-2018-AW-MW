using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Mail
    {
        public int MailID { get; set; }
        public string Address { get; set; }

        //Entity
        //public virtual Action Actions { get; set; }
        public Mail() { }
        public Mail(string address)
        {
            Address = address;
        }
    }
}
