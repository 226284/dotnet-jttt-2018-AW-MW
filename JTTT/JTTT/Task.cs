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
        //public string Name { get; set; }
        public virtual Action Action { get; set; } //= new Action();
        public virtual Condition Condition { get; set; }// = new Condition();
        public Time Time { get; set; }

        public virtual Parameters Parameters { get; set; }

        // public virtual ListofTask ListofTasks { get; set; }

        public Task()
        {

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
