namespace EasyHosts.Terminal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablePayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_PAYMENT",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TYPE_PAYMENT = c.Int(nullable: false),
                        NAME_CARD = c.String(),
                        CVV = c.Int(nullable: false),
                        NUMBER_CARD = c.String(),
                        DATE_EXPIRE = c.DateTime(nullable: false),
                        USER_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_USER", t => t.USER_ID)
                .Index(t => t.USER_ID);
            
            AddColumn("dbo.TB_BOOKING", "DATE_CHECKIN", c => c.DateTime(nullable: false));
            AddColumn("dbo.TB_BOOKING", "DATE_CHECKOUT", c => c.DateTime(nullable: false));
            AddColumn("dbo.TB_BOOKING", "VALUE_BOOKING", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_PAYMENT", "USER_ID", "dbo.TB_USER");
            DropIndex("dbo.TB_PAYMENT", new[] { "USER_ID" });
            DropColumn("dbo.TB_BOOKING", "VALUE_BOOKING");
            DropColumn("dbo.TB_BOOKING", "DATE_CHECKOUT");
            DropColumn("dbo.TB_BOOKING", "DATE_CHECKIN");
            DropTable("dbo.TB_PAYMENT");
        }
    }
}
