namespace tattlr.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Colin1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Reports", "Longitude", c => c.Double(nullable: false));
            DropColumn("dbo.Reports", "Location_Latitude");
            DropColumn("dbo.Reports", "Location_Longitude");
            DropColumn("dbo.Reports", "Location_Altitude");
            DropColumn("dbo.Reports", "Location_HorizontalAccuracy");
            DropColumn("dbo.Reports", "Location_VerticalAccuracy");
            DropColumn("dbo.Reports", "Location_Speed");
            DropColumn("dbo.Reports", "Location_Course");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reports", "Location_Course", c => c.Double(nullable: false));
            AddColumn("dbo.Reports", "Location_Speed", c => c.Double(nullable: false));
            AddColumn("dbo.Reports", "Location_VerticalAccuracy", c => c.Double(nullable: false));
            AddColumn("dbo.Reports", "Location_HorizontalAccuracy", c => c.Double(nullable: false));
            AddColumn("dbo.Reports", "Location_Altitude", c => c.Double(nullable: false));
            AddColumn("dbo.Reports", "Location_Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.Reports", "Location_Latitude", c => c.Double(nullable: false));
            DropColumn("dbo.Reports", "Longitude");
            DropColumn("dbo.Reports", "Latitude");
        }
    }
}
