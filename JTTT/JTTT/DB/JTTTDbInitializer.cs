using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT.DB
{
    class JTTTDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<JTTTDbContext>
    {
        
        /* Metoda do uzupelniania danych po zaoraniu bazy
         * 
         * protected override void Seed(StudiaDbContext context)
        {
            
            context.SaveChanges();
            base.Seed(context);
        }*/
    }
}
