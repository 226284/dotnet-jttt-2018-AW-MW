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

        public Dispatcher(ListofTasks _ListofTasks)
        {
            ListofTasks = _ListofTasks;
        }

        public bool Run()
        {
            foreach (Task t in ListofTasks.All())
            {
                if (t.Condition.Check("")) t.Action.Job();
                else return false;
            }
            return true;
        }
    }
}
