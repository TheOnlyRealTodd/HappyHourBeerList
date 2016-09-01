namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUnnecessaryAddressComplexityFromBarandBrewerModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "BusinessType_BusinessTypeId", "dbo.BusinessTypes");
            DropForeignKey("dbo.Bars", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Bars", "BusinessTypeId", "dbo.BusinessTypes");
            DropForeignKey("dbo.Brewers", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Brewers", "BusinessTypeId", "dbo.BusinessTypes");
            DropIndex("dbo.Addresses", new[] { "BusinessType_BusinessTypeId" });
            DropIndex("dbo.Bars", new[] { "BusinessTypeId" });
            DropIndex("dbo.Bars", new[] { "Address_AddressId" });
            DropIndex("dbo.Brewers", new[] { "BusinessTypeId" });
            DropIndex("dbo.Brewers", new[] { "Address_AddressId" });
            AddColumn("dbo.Bars", "Number", c => c.Int());
            AddColumn("dbo.Bars", "StreetName", c => c.String());
            AddColumn("dbo.Bars", "City", c => c.String());
            AddColumn("dbo.Bars", "State", c => c.String());
            AddColumn("dbo.Bars", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.Brewers", "Number", c => c.Int());
            AddColumn("dbo.Brewers", "StreetName", c => c.String());
            AddColumn("dbo.Brewers", "City", c => c.String());
            AddColumn("dbo.Brewers", "State", c => c.String());
            AddColumn("dbo.Brewers", "ZipCode", c => c.Int(nullable: false));
            DropColumn("dbo.Bars", "BusinessTypeId");
            DropColumn("dbo.Bars", "Address_AddressId");
            DropColumn("dbo.Brewers", "Address_AddressId");
            DropTable("dbo.Addresses");
            DropTable("dbo.BusinessTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BusinessTypes",
                c => new
                    {
                        BusinessTypeId = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BusinessTypeId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Number = c.Int(),
                        StreetName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        BusinessId = c.Int(nullable: false),
                        BusinessType_BusinessTypeId = c.Byte(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            AddColumn("dbo.Brewers", "Address_AddressId", c => c.Int());
            AddColumn("dbo.Brewers", "BusinessTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Bars", "Address_AddressId", c => c.Int());
            AddColumn("dbo.Bars", "BusinessTypeId", c => c.Byte(nullable: false));
            DropColumn("dbo.Brewers", "ZipCode");
            DropColumn("dbo.Brewers", "State");
            DropColumn("dbo.Brewers", "City");
            DropColumn("dbo.Brewers", "StreetName");
            DropColumn("dbo.Brewers", "Number");
            DropColumn("dbo.Bars", "ZipCode");
            DropColumn("dbo.Bars", "State");
            DropColumn("dbo.Bars", "City");
            DropColumn("dbo.Bars", "StreetName");
            DropColumn("dbo.Bars", "Number");
            CreateIndex("dbo.Brewers", "Address_AddressId");
            CreateIndex("dbo.Brewers", "BusinessTypeId");
            CreateIndex("dbo.Bars", "Address_AddressId");
            CreateIndex("dbo.Bars", "BusinessTypeId");
            CreateIndex("dbo.Addresses", "BusinessType_BusinessTypeId");
            AddForeignKey("dbo.Brewers", "BusinessTypeId", "dbo.BusinessTypes", "BusinessTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Brewers", "Address_AddressId", "dbo.Addresses", "AddressId");
            AddForeignKey("dbo.Bars", "BusinessTypeId", "dbo.BusinessTypes", "BusinessTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Bars", "Address_AddressId", "dbo.Addresses", "AddressId");
            AddForeignKey("dbo.Addresses", "BusinessType_BusinessTypeId", "dbo.BusinessTypes", "BusinessTypeId");
        }
    }
}
