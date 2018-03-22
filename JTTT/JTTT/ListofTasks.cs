using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class ListofTasks: IListofTasks
    {
        public virtual int ListofTasksId { get; set; }
        public virtual string Name { get; set; }
        public virtual BindingList<Task> listofTasks { get; set; }

        public ListofTasks()
        {
            listofTasks = new BindingList<Task>(); 
        }

        public void Add(Task task)
        {
            listofTasks.AllowNew = true;
            listofTasks.AllowRemove = false;
            listofTasks.RaiseListChangedEvents = true;
            listofTasks.Add(task);
        }

        public void Clear()
        {
            listofTasks.AllowNew = false;
            listofTasks.AllowRemove = true;
            listofTasks.RaiseListChangedEvents = true;
            listofTasks.Clear();
        }

        public BindingList<Task> All()
        {
            return this.listofTasks;
        }
    }
}
