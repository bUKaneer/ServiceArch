namespace ServiceArch.DataProviders.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskLists",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        Completed = c.Boolean(nullable: false),
                        TaskList_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaskLists", t => t.TaskList_Id)
                .Index(t => t.TaskList_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "TaskList_Id", "dbo.TaskLists");
            DropIndex("dbo.Tasks", new[] { "TaskList_Id" });
            DropTable("dbo.Tasks");
            DropTable("dbo.TaskLists");
        }
    }
}
