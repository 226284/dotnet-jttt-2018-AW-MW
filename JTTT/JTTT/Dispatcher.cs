using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JTTT
{
    public class Dispatcher : IDispatcher
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
                else
                {
                    MessageBox.Show("Error occured", "Error");
                    return false;
                }

            }
            MessageBox.Show("Done succesfully", "Info");
            return true;
        }
    }
}
