using EFDBFirstApproachExample1.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDBFirstApproachExample1.Controllers
{
    public class HomeController : Controller
    {
        [MyActionFilter]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}