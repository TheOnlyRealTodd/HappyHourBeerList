namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBusinessTypeToAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "BusinessType_BusinessTypeId", c => c.Byte());
            CreateIndex("dbo.Addresses", "BusinessType_BusinessTypeId");
            AddForeignKey("dbo.Addresses", "BusinessType_BusinessTypeId", "dbo.BusinessTypes", "BusinessTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "BusinessType_BusinessTypeId", "dbo.BusinessTypes");
            DropIndex("dbo.Addresses", new[] { "BusinessType_BusinessTypeId" });
            DropColumn("dbo.Addresses", "BusinessType_BusinessTypeId");
        }
    }
}
