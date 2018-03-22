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
        ListofTask ListofTask = new ListofTask();

        public Dispatcher(ListofTask _ListofTask)
        {
            ListofTask = _ListofTask;
        }

        public bool Run()
        {
            foreach (Task t in ListofTask.All())
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
