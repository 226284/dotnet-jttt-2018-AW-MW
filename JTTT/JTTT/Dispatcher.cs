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

        public async void Run()
        {
            foreach (Task t in ListofTask.All())
            {

                bool check = await t.Condition.Check(t.Parameters);
                if (check) t.Action.Job(t.Parameters);
            }
            MessageBox.Show("Done succesfully", "Info");
        }
    }
}
