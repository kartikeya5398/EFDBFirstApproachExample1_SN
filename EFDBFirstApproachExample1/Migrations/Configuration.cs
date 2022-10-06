namespace EFDBFirstApproachExample1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDBFirstApproachExample1.Models.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFDBFirstApproachExample1.Models.CompanyDbContext context)
        {
            context.Brands.AddOrUpdate(new Models.Brand() { BrandID = 1, BrandName = "Samsung" });
            context.Categories.AddOrUpdate(new Models.Category() { CategoryID = 1, CategoryName = "Mobile" });
            context.Products.AddOrUpdate(new Models.Product() { ProductID = 1, ProductName = "Samsung Galaxy A72", CategoryID = 1, BrandID = 1, Active = true, AvailabilityStatus = "InStock", Price = 25000, Photo = null, DateOfPurchase = DateTime.Now });
        }
    }
}
