namespace EFDBFirstApproachExample1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Company.DataLayer.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Company.DataLayer.CompanyDbContext context)
        {
            //This method will be called after Migrating to the Latest Version

            //context.Brands.AddOrUpdate(new Models.Brand() { BrandID = 1, BrandName = "Samsung" });
            //context.Categories.AddOrUpdate(new Models.Category() { CategoryID = 1, CategoryName = "Mobile" });
            //context.Products.AddOrUpdate(new Models.Product() { ProductID = 1, ProductName = "Samsung Galaxy A72", CategoryID = 1, BrandID = 1, Active = true, AvailabilityStatus = "InStock", Price = 25000, Photo = null, DateOfPurchase = DateTime.Now });
        }
    }
}
