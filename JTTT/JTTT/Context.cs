using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Context : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<ListofTask> ListofTasks { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Key> Keys { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<Mail> Mails { get; set; }
    }
}
