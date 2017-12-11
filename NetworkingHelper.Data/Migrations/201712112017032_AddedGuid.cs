namespace NetworkingHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConnectionEntity", "UserID", c => c.Guid(nullable: false));
            DropColumn("dbo.EventEntity", "UserID");
            AddColumn("dbo.EventEntity", "UserID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventEntity", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.ConnectionEntity", "UserID");
        }
    }
}
