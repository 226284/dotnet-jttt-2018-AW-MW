using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Action Action { get; set; }
        public Condition Condition { get; set; }
        public Time Time { get; set; }

        public virtual ListofTask ListofTasks { get; set; }

        /*public Task(Action action, Condition condition, Time time)
        {
            Action = action;
            Condition = condition;
            Time = time;
            //this.ListofTask = new ListofTask();
        }*/

        public override string ToString()
        {
            return String.Format("If: {0} Then: {1}", Condition.ToString(), Action.ToString());
        }
    }
}
