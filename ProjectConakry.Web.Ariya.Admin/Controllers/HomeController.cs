﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Admin.Controllers
{
    public class HomeController : Controller
    {
        [ConakryAdminAuthorize]
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult About()
        {           
            return View();
        }

        public ActionResult Contact()
        {          
            return View();
        }
    }
}
