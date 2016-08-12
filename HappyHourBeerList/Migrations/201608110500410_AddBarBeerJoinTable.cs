namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBarBeerJoinTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BarBeers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BarId = c.Int(nullable: false),
                        BeerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bars", t => t.BarId, cascadeDelete: true)
                .ForeignKey("dbo.Beers", t => t.BeerId, cascadeDelete: true)
                .Index(t => t.BarId)
                .Index(t => t.BeerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BarBeers", "BeerId", "dbo.Beers");
            DropForeignKey("dbo.BarBeers", "BarId", "dbo.Bars");
            DropIndex("dbo.BarBeers", new[] { "BeerId" });
            DropIndex("dbo.BarBeers", new[] { "BarId" });
            DropTable("dbo.BarBeers");
        }
    }
}
