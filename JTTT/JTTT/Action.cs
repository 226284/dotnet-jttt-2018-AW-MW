using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Action: IAction
    {
        private Mail Mail = new Mail();

        Action(Mail mail)
        {
            Mail = mail;
        }
        public void Job()
        {
            //send mail or something
        }
    }
}
