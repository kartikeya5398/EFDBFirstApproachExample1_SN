﻿using EFDBFirstApproachExample1.Filter;
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
        [MyResultFilter]
        [OutputCache(Duration =60)]
        // GET: Home
        public ActionResult Index()
        {
            //throw new Exception("Some Exception For testing purpose");        //Lec-108 HandleError
            return View();
        }
    }
}