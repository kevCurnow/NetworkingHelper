namespace NetworkingHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConnectionEntity", "EventID", "dbo.EventEntity");
            DropIndex("dbo.ConnectionEntity", new[] { "EventID" });
            RenameColumn(table: "dbo.ConnectionEntity", name: "EventID", newName: "Events_EventID");
            AddColumn("dbo.ConnectionEntity", "EventName", c => c.String(nullable: false));
            AlterColumn("dbo.ConnectionEntity", "Events_EventID", c => c.Int());
            CreateIndex("dbo.ConnectionEntity", "Events_EventID");
            AddForeignKey("dbo.ConnectionEntity", "Events_EventID", "dbo.EventEntity", "EventID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConnectionEntity", "Events_EventID", "dbo.EventEntity");
            DropIndex("dbo.ConnectionEntity", new[] { "Events_EventID" });
            AlterColumn("dbo.ConnectionEntity", "Events_EventID", c => c.Int(nullable: false));
            DropColumn("dbo.ConnectionEntity", "EventName");
            RenameColumn(table: "dbo.ConnectionEntity", name: "Events_EventID", newName: "EventID");
            CreateIndex("dbo.ConnectionEntity", "EventID");
            AddForeignKey("dbo.ConnectionEntity", "EventID", "dbo.EventEntity", "EventID", cascadeDelete: true);
        }
    }
}
