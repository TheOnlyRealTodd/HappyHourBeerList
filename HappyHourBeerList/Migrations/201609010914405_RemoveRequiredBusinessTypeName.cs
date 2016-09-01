namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredBusinessTypeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BusinessTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BusinessTypes", "Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
