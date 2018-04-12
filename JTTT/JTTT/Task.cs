using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Task
    {
        public int TaskID { get; set; }
        public string Name { get; set; }
        public virtual Action Action { get; set; } //= new Action();
        public virtual Condition Condition { get; set; }// = new Condition();
        public Time Time { get; set; }

        // public virtual ListofTask ListofTasks { get; set; }

        public Task()
        {
           // Action = new Action();
           // Condition = new Condition();
        }
        public Task(Action action, Condition condition, Time time)
        {
            Action = action;
            Condition = condition;
            Time = time;
            //this.ListofTask = new ListofTask();
        }

        public override string ToString()
        {
            return String.Format("If: {0} Then: {1}", Condition.ToString(), Action.ToString());
        }
    }
}
