using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Action : IAction
    {
       
        public int ActionID { get; set; }
        public string Name { get; set; }
        public virtual Mail Mail { get; set; }
       

       protected string fromMail = "amadi@scz.pl";

        public Action()
        {

        }
        public Action (Mail mail)
        {
            Mail = mail;
        }
        public virtual void Job()
        {
            //send mail or something
        }
    }
}
