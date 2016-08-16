namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeIbuNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Beers", "Ibu", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Beers", "Ibu", c => c.Byte(nullable: false));
        }
    }
}
