namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeCurrentBeveragesFromBarandDto : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bars", "CurrentBeverages");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bars", "CurrentBeverages", c => c.String());
        }
    }
}
