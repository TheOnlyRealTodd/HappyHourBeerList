namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyRelationshipForBarsandBeers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BarsBeers",
                c => new
                    {
                        Bar_BarId = c.Int(nullable: false),
                        Beer_BeerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Bar_BarId, t.Beer_BeerId })
                .ForeignKey("dbo.Bars", t => t.Bar_BarId, cascadeDelete: false)
                .ForeignKey("dbo.Beers", t => t.Beer_BeerId, cascadeDelete: false)
                .Index(t => t.Bar_BarId)
                .Index(t => t.Beer_BeerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BarsBeers", "Beer_BeerId", "dbo.Beers");
            DropForeignKey("dbo.BarsBeers", "Bar_BarId", "dbo.Bars");
            DropIndex("dbo.BarsBeers", new[] { "Beer_BeerId" });
            DropIndex("dbo.BarsBeers", new[] { "Bar_BarId" });
            DropTable("dbo.BarsBeers");
        }
    }
}
