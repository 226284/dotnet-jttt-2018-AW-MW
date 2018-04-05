using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class ListofTask: IListofTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual BindingList<Task> Tasks { get; set; }

        public ListofTask()
        {
            this.Tasks = new BindingList<Task>(); 
        }

        public void Add(Task task)
        {
            Tasks.AllowNew = true;
            Tasks.AllowRemove = false;
            Tasks.RaiseListChangedEvents = true;
            Tasks.Add(task);
        }

        public void Clear()
        {
            Tasks.AllowNew = false;
            Tasks.AllowRemove = true;
            Tasks.RaiseListChangedEvents = true;
            Tasks.Clear();
        }

        public BindingList<Task> All()
        {
            return this.Tasks;
        }
    }
}
