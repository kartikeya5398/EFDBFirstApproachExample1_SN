﻿//using EFDBFirstApproachExample1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DomainModels;
using EFDBFirstApproachExample1.Filter;
using Company.DataLayer;

namespace EFDBFirstApproachExample1.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}