namespace EasyHosts.Terminal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnNameTableUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_USER", "NAME", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TB_USER", "NAME");
        }
    }
}
