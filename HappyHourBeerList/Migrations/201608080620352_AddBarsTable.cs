namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBarsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GooglePlaceId = c.String(),
                        SundayDiscounts = c.String(),
                        MondayDiscounts = c.String(),
                        TuesdayDiscounts = c.String(),
                        WednesdayDiscounts = c.String(),
                        ThursdayDiscounts = c.String(),
                        FridayDiscounts = c.String(),
                        SaturdayDiscounts = c.String(),
                        LastUpdated = c.DateTime(nullable: false),
                        CurrentBeverages = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bars");
        }
    }
}
