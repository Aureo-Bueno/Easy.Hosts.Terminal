namespace EasyHosts.Terminal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesBedroomAndTypeBedroomAndEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_BEDROOM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NAME_BEDROOM = c.String(nullable: false, maxLength: 255),
                        VALUE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DESCRIPTION = c.String(nullable: false, maxLength: 255),
                        STATUS = c.Int(nullable: false),
                        TYPE_BEDROOM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_TYPE_BEDROOM", t => t.TYPE_BEDROOM, cascadeDelete: true)
                .Index(t => t.TYPE_BEDROOM);
            
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
            
            CreateTable(
                "dbo.TB_EVENT",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NAME_EVENT = c.String(maxLength: 50),
                        ORGANIZER = c.String(maxLength: 100),
                        DATE_EVENT = c.DateTime(nullable: false),
                        EVENTS_PLACE = c.String(maxLength: 150),
                        DESCRIPTION_EVENT = c.String(maxLength: 100),
                        ATTRACTIONS = c.String(maxLength: 100),
                        TYPE_EVENT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_BEDROOM", "TYPE_BEDROOM", "dbo.TB_TYPE_BEDROOM");
            DropIndex("dbo.TB_BEDROOM", new[] { "TYPE_BEDROOM" });
            DropTable("dbo.TB_EVENT");
            DropTable("dbo.TB_TYPE_BEDROOM");
            DropTable("dbo.TB_BEDROOM");
        }
    }
}
