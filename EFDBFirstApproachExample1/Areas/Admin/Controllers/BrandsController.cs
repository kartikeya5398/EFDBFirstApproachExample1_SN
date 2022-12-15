using EFDBFirstApproachExample1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstApproachExample1.Filter;

namespace EFDBFirstApproachExample1.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class BrandsController : Controller
    {
        // GET: Admin/Brands
        public ActionResult Index()
        {
                CompanyDbContext db = new CompanyDbContext();
                //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
                List<Brand> brands = db.Brands.ToList();
                return View(brands);
        }
    }
}