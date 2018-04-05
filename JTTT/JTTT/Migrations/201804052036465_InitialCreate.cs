namespace JTTT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Conditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ListofTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Time_time = c.String(),
                        Action_Id = c.Int(),
                        Condition_Id = c.Int(),
                        ListofTasks_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actions", t => t.Action_Id)
                .ForeignKey("dbo.Conditions", t => t.Condition_Id)
                .ForeignKey("dbo.ListofTasks", t => t.ListofTasks_Id)
                .Index(t => t.Action_Id)
                .Index(t => t.Condition_Id)
                .Index(t => t.ListofTasks_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ListofTasks_Id", "dbo.ListofTasks");
            DropForeignKey("dbo.Tasks", "Condition_Id", "dbo.Conditions");
            DropForeignKey("dbo.Tasks", "Action_Id", "dbo.Actions");
            DropIndex("dbo.Tasks", new[] { "ListofTasks_Id" });
            DropIndex("dbo.Tasks", new[] { "Condition_Id" });
            DropIndex("dbo.Tasks", new[] { "Action_Id" });
            DropTable("dbo.Tasks");
            DropTable("dbo.ListofTasks");
            DropTable("dbo.Conditions");
            DropTable("dbo.Actions");
        }
    }
}
