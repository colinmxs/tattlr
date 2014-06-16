namespace tattlr.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Colin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AzureId = c.String(),
                        Uri = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Location_Latitude = c.Double(nullable: false),
                        Location_Longitude = c.Double(nullable: false),
                        Location_Altitude = c.Double(nullable: false),
                        Location_HorizontalAccuracy = c.Double(nullable: false),
                        Location_VerticalAccuracy = c.Double(nullable: false),
                        Location_Speed = c.Double(nullable: false),
                        Location_Course = c.Double(nullable: false),
                        ImageUrl = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.ImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "ImageId", "dbo.Images");
            DropIndex("dbo.Reports", new[] { "ImageId" });
            DropTable("dbo.Reports");
            DropTable("dbo.Images");
        }
    }
}
