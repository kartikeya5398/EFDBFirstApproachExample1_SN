namespace EFDBFirstApproachExample1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime(nullable: false));
        }
    }
}
