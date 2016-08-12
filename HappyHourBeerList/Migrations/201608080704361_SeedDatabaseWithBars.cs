namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDatabaseWithBars : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Bars (GooglePlaceId, Name, CurrentBeverages, LastUpdated) VALUES ('ChIJoWDQdhBy3IARsa-c9eZot1k', 'PAON', 'Long Island Iced Tea, Latitude 33 Honey Hips', CURRENT_TIMESTAMP)");
        }
        
        public override void Down()
        {
        }
    }
}
