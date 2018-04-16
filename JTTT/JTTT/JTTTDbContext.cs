using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class JTTTDbContext : DbContext
    {
        public JTTTDbContext()
            : base("JTTT23")
        {

        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Parameters> Parameters { get; set; }
        public DbSet<ListofTask> ListofTasks { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        /*
        public DbSet<Key> Keys { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        */

    }
}
