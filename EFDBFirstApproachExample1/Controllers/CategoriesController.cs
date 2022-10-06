using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstApproachExample1.Models;

namespace EFDBFirstApproachExample1.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            List<Category> categories =db.Categories.ToList();
            return View(categories);
        }
    }
}