using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//using EFDBFirstApproachExample1.Migrations;

namespace EFDBFirstApproachExample1.Models
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base("EFCodeFirstEntities")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDbContext, Configuration>());
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}