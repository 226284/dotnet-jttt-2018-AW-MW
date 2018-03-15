using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Dispatcher : IDispatcher
    {
        ListofTasks ListofTasks = new ListofTasks();

        private int actionID;
        private int conditionID;

        public Dispatcher()
        {
           
        }

        public bool Run()
        {
            return true;
        }
    }
}
