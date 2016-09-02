namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGooglePlaceIdToBrewer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brewers", "GooglePlaceId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brewers", "GooglePlaceId");
        }
    }
}
