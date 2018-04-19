using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Task
    {
        public int Id { get; set; }
        public virtual Action Action { get; set; }
        public virtual Condition Condition { get; set; }
        public Time Time { get; set; }
        public virtual Parameters Parameters { get; set; }

        public Task()
        {

        }

        public Task(Action action, Condition condition, Parameters parameters, Time time)
        {
            Action = action;
            Condition = condition;
            Time = time;
            Parameters = parameters;
        }

        public override string ToString()
        {
            return String.Format("If: {0} Then: {1}", Condition.ToString(), Action.ToString());
        }
    }
}
