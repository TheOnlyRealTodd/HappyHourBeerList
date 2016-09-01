namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDbWithBusinessTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BusinessTypes VALUES (1, 'Bar')");
            Sql("INSERT INTO BusinessTypes VALUES (2, 'Brewer')");
        }
        
        public override void Down()
        {
        }
    }
}
