namespace EasyHosts.Terminal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableAlbumBedroom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_ALBUM_BEDROOM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BEDROOM_ID = c.Int(nullable: false),
                        PICTURE = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_BEDROOM", t => t.BEDROOM_ID, cascadeDelete: true)
                .Index(t => t.BEDROOM_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_ALBUM_BEDROOM", "BEDROOM_ID", "dbo.TB_BEDROOM");
            DropIndex("dbo.TB_ALBUM_BEDROOM", new[] { "BEDROOM_ID" });
            DropTable("dbo.TB_ALBUM_BEDROOM");
        }
    }
}
