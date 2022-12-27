using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
//using EFDBFirstApproachExample1.Migrations;
//using EFDBFirstApproachExample1.Models;
using Company.DomainModels;

namespace Company.DataLayer
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
