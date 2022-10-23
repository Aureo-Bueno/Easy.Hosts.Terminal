namespace EasyHosts.Terminal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_ALBUM_EVENT",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EVENT_ID = c.Int(nullable: false),
                        PICTURE = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_EVENT", t => t.EVENT_ID, cascadeDelete: true)
                .Index(t => t.EVENT_ID);
            
            CreateTable(
                "dbo.TB_PRODUCT",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NAME_PRODUCT = c.String(),
                        VALUE = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.TB_PERFIL", "DESCRIPTION", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_ALBUM_EVENT", "EVENT_ID", "dbo.TB_EVENT");
            DropIndex("dbo.TB_ALBUM_EVENT", new[] { "EVENT_ID" });
            AlterColumn("dbo.TB_PERFIL", "DESCRIPTION", c => c.String());
            DropTable("dbo.TB_PRODUCT");
            DropTable("dbo.TB_ALBUM_EVENT");
        }
    }
}
