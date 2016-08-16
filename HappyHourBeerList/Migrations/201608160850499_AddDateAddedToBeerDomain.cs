namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAddedToBeerDomain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beers", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Beers", "DateAdded");
        }
    }
}
