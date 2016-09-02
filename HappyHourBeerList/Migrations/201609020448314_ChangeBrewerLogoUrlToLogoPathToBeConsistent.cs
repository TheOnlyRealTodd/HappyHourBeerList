namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBrewerLogoUrlToLogoPathToBeConsistent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brewers", "LogoPath", c => c.String());
            DropColumn("dbo.Brewers", "LogoUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Brewers", "LogoUrl", c => c.String());
            DropColumn("dbo.Brewers", "LogoPath");
        }
    }
}
