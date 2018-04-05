namespace JTTT.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JTTT.ListofTaskComplex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "JTTT.ListofTaskComplex";
        }

        protected override void Seed(JTTT.ListofTaskComplex context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
