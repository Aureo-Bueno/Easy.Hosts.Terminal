namespace EasyHosts.Terminal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnStatusTableBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_BOOKING", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TB_BOOKING", "Status");
        }
    }
}
