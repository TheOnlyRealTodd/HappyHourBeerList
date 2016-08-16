namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropOldBarBeer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BarBeers", "BarId", "dbo.Bars");
            DropForeignKey("dbo.BarBeers", "BeerId", "dbo.Beers");
            DropIndex("dbo.BarBeers", new[] { "BarId" });
            DropIndex("dbo.BarBeers", new[] { "BeerId" });
            DropTable("dbo.BarBeers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BarBeers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BarId = c.Int(nullable: false),
                        BeerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.BarBeers", "BeerId");
            CreateIndex("dbo.BarBeers", "BarId");
            AddForeignKey("dbo.BarBeers", "BeerId", "dbo.Beers", "BeerId", cascadeDelete: true);
            AddForeignKey("dbo.BarBeers", "BarId", "dbo.Bars", "BarId", cascadeDelete: true);
        }
    }
}
