using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Task
    {
        public int TaskId { get; set; }
        public virtual string Name { get; set; }
        public virtual Action Action { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual Time Time { get; set; }

        public virtual ListofTasks ListofTasks { get; set; }

        public Task(Action action, Condition condition, Time time)
        {
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
