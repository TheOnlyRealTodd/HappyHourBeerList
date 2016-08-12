namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeBarPlaceIdNonNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bars", "GooglePlaceId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bars", "GooglePlaceId", c => c.String());
        }
    }
}
