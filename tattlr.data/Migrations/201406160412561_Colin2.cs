namespace tattlr.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Colin2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Images", "AzureId");
            DropColumn("dbo.Reports", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reports", "ImageUrl", c => c.String());
            AddColumn("dbo.Images", "AzureId", c => c.String());
        }
    }
}
