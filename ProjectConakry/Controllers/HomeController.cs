﻿using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectConakry.Controllers
{
    public class HomeController : Controller
    {
       
        [HttpGet]
        [OutputCache(Duration = 120)]
        public ActionResult Index()
        {            
            return View();
        }

        
      
    }
}