using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Action : IAction
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Entity
        //public virtual Mail Mail { get; set; }
        public Mail Mail { get; set; }
        protected string fromMail = "amadi@scz.pl";

        public Action(Mail mail)
        {
            //  Mail = mail;
        }
        public virtual void Job()
        {
            //send mail or something
        }
    }
}
