namespace EasyHosts.Terminal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_ALBUM_BEDROOM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BEDROOM_ID = c.Int(nullable: false),
                        PICTURE = c.Binary(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_BEDROOM", t => t.BEDROOM_ID, cascadeDelete: true)
                .Index(t => t.BEDROOM_ID);
            
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
                        PICTURE = c.Binary(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_TYPE_BEDROOM", t => t.TYPE_BEDROOM, cascadeDelete: true)
                .Index(t => t.TYPE_BEDROOM);
            
            CreateTable(
                "dbo.TB_TYPE_BEDROOM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NAME_TYPE_BEDROOM = c.String(nullable: false, maxLength: 255),
                        AMOUNT_OF_PEOPLE = c.Int(nullable: false),
                        AMOUNT_OF_BED = c.Int(nullable: false),
                        APARTMENT_AMENITIES = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TB_ALBUM_EVENT",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EVENT_ID = c.Int(nullable: false),
                        PICTURE = c.Binary(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_EVENT", t => t.EVENT_ID, cascadeDelete: true)
                .Index(t => t.EVENT_ID);
            
            CreateTable(
                "dbo.TB_EVENT",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NAME_EVENT = c.String(maxLength: 50),
                        ORGANIZER = c.String(maxLength: 100),
                        DATE_EVENT = c.DateTime(nullable: false),
                        EVENTS_PLACE = c.String(maxLength: 150),
                        PICTURE = c.Binary(),
                        DESCRIPTION_EVENT = c.String(maxLength: 100),
                        ATTRACTIONS = c.String(maxLength: 100),
                        TYPE_EVENT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TB_BOOKING",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CODE_BOOKING = c.String(),
                        USER_ID = c.Int(nullable: false),
                        DATE_CHECKIN = c.DateTime(nullable: false),
                        DATE_CHECKOUT = c.DateTime(nullable: false),
                        VALUE_BOOKING = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BEDROOM_ID = c.Int(nullable: false),
                        STATUS = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_BEDROOM", t => t.BEDROOM_ID, cascadeDelete: true)
                .ForeignKey("dbo.TB_USER", t => t.USER_ID, cascadeDelete: true)
                .Index(t => t.USER_ID)
                .Index(t => t.BEDROOM_ID);
            
            CreateTable(
                "dbo.TB_USER",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NAME = c.String(nullable: false, maxLength: 200),
                        EMAIL = c.String(),
                        PASSWORD = c.String(),
                        CONFIRM_PASSWORD = c.String(),
                        STATUS = c.Int(nullable: false),
                        CPF = c.String(),
                        HASH = c.String(),
                        PERFIL_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_PERFIL", t => t.PERFIL_ID, cascadeDelete: true)
                .Index(t => t.PERFIL_ID);
            
            CreateTable(
                "dbo.TB_PERFIL",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DESCRIPTION = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TB_PRODUCT",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NAME_PRODUCT = c.String(),
                        VALUE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QUANTITY_PRODUCT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_BOOKING", "USER_ID", "dbo.TB_USER");
            DropForeignKey("dbo.TB_USER", "PERFIL_ID", "dbo.TB_PERFIL");
            DropForeignKey("dbo.TB_BOOKING", "BEDROOM_ID", "dbo.TB_BEDROOM");
            DropForeignKey("dbo.TB_ALBUM_EVENT", "EVENT_ID", "dbo.TB_EVENT");
            DropForeignKey("dbo.TB_ALBUM_BEDROOM", "BEDROOM_ID", "dbo.TB_BEDROOM");
            DropForeignKey("dbo.TB_BEDROOM", "TYPE_BEDROOM", "dbo.TB_TYPE_BEDROOM");
            DropIndex("dbo.TB_USER", new[] { "PERFIL_ID" });
            DropIndex("dbo.TB_BOOKING", new[] { "BEDROOM_ID" });
            DropIndex("dbo.TB_BOOKING", new[] { "USER_ID" });
            DropIndex("dbo.TB_ALBUM_EVENT", new[] { "EVENT_ID" });
            DropIndex("dbo.TB_BEDROOM", new[] { "TYPE_BEDROOM" });
            DropIndex("dbo.TB_ALBUM_BEDROOM", new[] { "BEDROOM_ID" });
            DropTable("dbo.TB_PRODUCT");
            DropTable("dbo.TB_PERFIL");
            DropTable("dbo.TB_USER");
            DropTable("dbo.TB_BOOKING");
            DropTable("dbo.TB_EVENT");
            DropTable("dbo.TB_ALBUM_EVENT");
            DropTable("dbo.TB_TYPE_BEDROOM");
            DropTable("dbo.TB_BEDROOM");
            DropTable("dbo.TB_ALBUM_BEDROOM");
        }
    }
}
