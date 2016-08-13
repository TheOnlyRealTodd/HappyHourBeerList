namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorDomainModelsAndControllers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "BarId", "dbo.Bars");
            DropForeignKey("dbo.BarBeers", "BarId", "dbo.Bars");
            DropForeignKey("dbo.BarBeers", "BeerId", "dbo.Beers");
            DropPrimaryKey("dbo.Addresses");
            DropPrimaryKey("dbo.Bars");
            DropPrimaryKey("dbo.Beers");
            DropColumn("dbo.Addresses", "Id");
            DropColumn("dbo.Bars", "Id");
            DropColumn("dbo.Beers", "Id");
            AddColumn("dbo.Bars", "BarId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Beers", "BeerId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Addresses", "BarId");
            AddPrimaryKey("dbo.Beers", "BeerId");
            AddPrimaryKey("dbo.Bars", "BarId");
            AddForeignKey("dbo.Addresses", "BarId", "dbo.Bars", "BarId");
            AddForeignKey("dbo.BarBeers", "BarId", "dbo.Bars", "BarId", cascadeDelete: true);
            AddForeignKey("dbo.BarBeers", "BeerId", "dbo.Beers", "BeerId", cascadeDelete: true);

        }
        
        public override void Down()
        {
            AddColumn("dbo.Beers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Bars", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Addresses", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.BarBeers", "BeerId", "dbo.Beers");
            DropForeignKey("dbo.BarBeers", "BarId", "dbo.Bars");
            DropForeignKey("dbo.Addresses", "BarId", "dbo.Bars");
            DropPrimaryKey("dbo.Beers");
            DropPrimaryKey("dbo.Bars");
            DropPrimaryKey("dbo.Addresses");
            DropColumn("dbo.Beers", "BeerId");
            DropColumn("dbo.Bars", "BarId");
            AddPrimaryKey("dbo.Beers", "Id");
            AddPrimaryKey("dbo.Bars", "Id");
            AddPrimaryKey("dbo.Addresses", "Id");
            AddForeignKey("dbo.BarBeers", "BeerId", "dbo.Beers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BarBeers", "BarId", "dbo.Bars", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "BarId", "dbo.Bars", "Id", cascadeDelete: true);
        }
    }
}
