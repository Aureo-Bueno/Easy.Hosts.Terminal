namespace EasyHosts.Terminal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableBedroom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_BEDROOM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NAME_BEDROOM = c.String(),
                        VALUE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AMOUNT_OF_PEOPLE = c.Int(nullable: false),
                        AMOUNT_OF_BED = c.Int(nullable: false),
                        DESCRIPTION = c.String(),
                        APARTMENT_AMENITIES = c.String(),
                        STATUS = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TB_BEDROOM");
        }
    }
}
