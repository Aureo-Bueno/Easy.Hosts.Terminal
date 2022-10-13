namespace EasyHosts.Terminal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableTypeBedroom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_TYPE_BEDROOM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AMOUNT_OF_PEOPLE = c.Int(nullable: false),
                        AMOUNT_OF_BED = c.Int(nullable: false),
                        APARTMENT_AMENITIES = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.TB_BEDROOM", "TYPE_BEDROOM", c => c.Int(nullable: false));
            AlterColumn("dbo.TB_BEDROOM", "NAME_BEDROOM", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.TB_BEDROOM", "DESCRIPTION", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.TB_BEDROOM", "TYPE_BEDROOM");
            AddForeignKey("dbo.TB_BEDROOM", "TYPE_BEDROOM", "dbo.TB_TYPE_BEDROOM", "ID", cascadeDelete: true);
            DropColumn("dbo.TB_BEDROOM", "AMOUNT_OF_PEOPLE");
            DropColumn("dbo.TB_BEDROOM", "AMOUNT_OF_BED");
            DropColumn("dbo.TB_BEDROOM", "APARTMENT_AMENITIES");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_BEDROOM", "APARTMENT_AMENITIES", c => c.String());
            AddColumn("dbo.TB_BEDROOM", "AMOUNT_OF_BED", c => c.Int(nullable: false));
            AddColumn("dbo.TB_BEDROOM", "AMOUNT_OF_PEOPLE", c => c.Int(nullable: false));
            DropForeignKey("dbo.TB_BEDROOM", "TYPE_BEDROOM", "dbo.TB_TYPE_BEDROOM");
            DropIndex("dbo.TB_BEDROOM", new[] { "TYPE_BEDROOM" });
            AlterColumn("dbo.TB_BEDROOM", "DESCRIPTION", c => c.String());
            AlterColumn("dbo.TB_BEDROOM", "NAME_BEDROOM", c => c.String());
            DropColumn("dbo.TB_BEDROOM", "TYPE_BEDROOM");
            DropTable("dbo.TB_TYPE_BEDROOM");
        }
    }
}
