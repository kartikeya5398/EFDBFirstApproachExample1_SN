namespace EFDBFirstApproachExample1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuantityColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "quantity", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "quantity");
        }
    }
}
