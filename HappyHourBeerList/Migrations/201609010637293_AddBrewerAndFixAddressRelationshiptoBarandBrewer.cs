namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBrewerAndFixAddressRelationshiptoBarandBrewer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "BarId", "dbo.Bars");
            DropIndex("dbo.Addresses", new[] { "BarId" });
            DropPrimaryKey("dbo.Addresses");
            CreateTable(
                "dbo.BusinessTypes",
                c => new
                    {
                        BusinessTypeId = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BusinessTypeId);
            
            CreateTable(
                "dbo.Brewers",
                c => new
                    {
                        BrewerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        LogoUrl = c.String(),
                        LastUpdated = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(),
                        Address_AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.BrewerId)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId)
                .Index(t => t.Address_AddressId);
            
            AddColumn("dbo.Addresses", "AddressId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Addresses", "BusinessTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Addresses", "BusinessId", c => c.Int(nullable: false));
            AddColumn("dbo.Bars", "BusinessTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Bars", "Address_AddressId", c => c.Int());
            AddColumn("dbo.Beers", "Brewer_BrewerId", c => c.Int());
            AddPrimaryKey("dbo.Addresses", "AddressId");
            CreateIndex("dbo.Addresses", "BusinessTypeId");
            CreateIndex("dbo.Bars", "BusinessTypeId");
            CreateIndex("dbo.Bars", "Address_AddressId");
            CreateIndex("dbo.Beers", "Brewer_BrewerId");
            AddForeignKey("dbo.Addresses", "BusinessTypeId", "dbo.BusinessTypes", "BusinessTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Bars", "BusinessTypeId", "dbo.BusinessTypes", "BusinessTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Beers", "Brewer_BrewerId", "dbo.Brewers", "BrewerId");
            AddForeignKey("dbo.Bars", "Address_AddressId", "dbo.Addresses", "AddressId");
            DropColumn("dbo.Addresses", "BarId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "BarId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Bars", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Beers", "Brewer_BrewerId", "dbo.Brewers");
            DropForeignKey("dbo.Brewers", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Bars", "BusinessTypeId", "dbo.BusinessTypes");
            DropForeignKey("dbo.Addresses", "BusinessTypeId", "dbo.BusinessTypes");
            DropIndex("dbo.Brewers", new[] { "Address_AddressId" });
            DropIndex("dbo.Beers", new[] { "Brewer_BrewerId" });
            DropIndex("dbo.Bars", new[] { "Address_AddressId" });
            DropIndex("dbo.Bars", new[] { "BusinessTypeId" });
            DropIndex("dbo.Addresses", new[] { "BusinessTypeId" });
            DropPrimaryKey("dbo.Addresses");
            DropColumn("dbo.Beers", "Brewer_BrewerId");
            DropColumn("dbo.Bars", "Address_AddressId");
            DropColumn("dbo.Bars", "BusinessTypeId");
            DropColumn("dbo.Addresses", "BusinessId");
            DropColumn("dbo.Addresses", "BusinessTypeId");
            DropColumn("dbo.Addresses", "AddressId");
            DropTable("dbo.Brewers");
            DropTable("dbo.BusinessTypes");
            AddPrimaryKey("dbo.Addresses", "BarId");
            CreateIndex("dbo.Addresses", "BarId");
            AddForeignKey("dbo.Addresses", "BarId", "dbo.Bars", "BarId");
        }
    }
}
