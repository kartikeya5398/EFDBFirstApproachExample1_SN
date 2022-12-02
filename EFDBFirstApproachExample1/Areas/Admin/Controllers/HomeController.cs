using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDBFirstApproachExample1.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home/index
        public ActionResult Index()
        {
            return View();
        }
    }
}