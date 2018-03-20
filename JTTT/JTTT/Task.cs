using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Task
    {
        public Action Action;
        public Condition Condition;
        //public Log Log;
        public Time Time;

        public Task(Action action, Condition condition, Time time)
        {
            //Log = log;
            Action = action;
            Condition = condition;
            Time = time;
        }

        public override string ToString()
        {
            return String.Format("If: {0} Then: {1}", Condition.ToString(), Action.ToString());
        }
    }
}
