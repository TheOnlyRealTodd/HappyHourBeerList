namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableDateAddedToBarModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bars", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bars", "DateAdded");
        }
    }
}
