﻿using ProjectConakry.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Admin.Controllers
{
    public class LogInController : Controller
    {
        private IAuthenticationService _authenticationService;

        public LogInController(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }
        [HttpGet]
        [OutputCache(Duration = 86400)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult TryLogIn(string email, string passWord)
        {
            if (_authenticationService.Authenticate(email, passWord, true)) 
                return RedirectToAction("Index", "Home");

            throw new UnauthorizedAccessException("Bad username or password");
        }

        public ActionResult SignOut()
        {            
            System.Web.HttpContext.Current.Session["currentUser"] = null;
            System.Web.HttpContext.Current.Session.Abandon();
            return RedirectToAction("Index", "Home");
        }




    }
}
