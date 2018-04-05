namespace JTTT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Keys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Urls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Actions", "Name", c => c.String());
            AlterColumn("dbo.Conditions", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Conditions", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.Actions", "Name", c => c.Int(nullable: false));
            DropTable("dbo.Urls");
            DropTable("dbo.Mails");
            DropTable("dbo.Keys");
        }
    }
}
