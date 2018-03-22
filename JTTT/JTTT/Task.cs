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
        public string Name { get; set; }
        public Action Action { get; set; }
        public Condition Condition { get; set; }
        public Time Time { get; set; }

        public virtual ListofTask ListofTask { get; set; }

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
