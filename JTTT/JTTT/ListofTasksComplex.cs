using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class ListofTaskComplex : DbContext
    {
        public DbSet<ListofTask> ListofTasks { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
