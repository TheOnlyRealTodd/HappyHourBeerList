namespace HappyHourBeerList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDuplicateBuffaloWildWings : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Bars WHERE id=3;");
        }
        
        public override void Down()
        {
        }
    }
}
