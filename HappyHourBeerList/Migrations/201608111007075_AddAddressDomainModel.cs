namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressDomainModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(),
                        StreetName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        BarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bars", t => t.BarId, cascadeDelete: true)
                .Index(t => t.BarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "BarId", "dbo.Bars");
            DropIndex("dbo.Addresses", new[] { "BarId" });
            DropTable("dbo.Addresses");
        }
    }
}
