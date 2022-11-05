namespace EasyHosts.Terminal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnHashPicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_BEDROOM", "PICTURE", c => c.String());
            AddColumn("dbo.TB_USER", "HASH", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TB_USER", "HASH");
            DropColumn("dbo.TB_BEDROOM", "PICTURE");
        }
    }
}
