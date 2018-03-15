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

        public Dispatcher(int _actionID, int _conditionID)
        {
            actionID = _actionID;
            conditionID = _conditionID;
        }

        public bool Run()
        {
            return true;
        }
    }
}
