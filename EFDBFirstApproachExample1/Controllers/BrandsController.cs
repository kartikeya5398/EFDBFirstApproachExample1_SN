using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstApproachExample1.Models;

namespace EFDBFirstApproachExample1.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}