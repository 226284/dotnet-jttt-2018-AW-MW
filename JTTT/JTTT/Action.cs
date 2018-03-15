using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Action: IAction
    {
        Mail Mail = new Mail();
        public void Job()
        {
            //send mail or something
        }
    }
}
