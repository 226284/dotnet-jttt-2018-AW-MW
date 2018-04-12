using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JTTT
{
    class Dispatcher : IDispatcher
    {
        public ListofTask ListofTask = new ListofTask();

        public Dispatcher(ListofTask listofTask)
        {
            ListofTask = listofTask;
        }

        public bool Run()
        {
            foreach (Task t in ListofTask.All())
            {
                if (t.Condition.Check(t.Parameters)) t.Action.Job(t.Parameters);
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
