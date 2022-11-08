namespace EasyHosts.Terminal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTypeColumnCodeBooking : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_BOOKING", "CODE_BOOKING", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_BOOKING", "CODE_BOOKING", c => c.Int(nullable: false));
        }
    }
}
