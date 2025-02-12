﻿using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class AccountController : AuthenticatedBaseController
    {
        //
        // GET: /Account/
        private Customer loggedInUser;

     
        public AccountController()
        {
            CustomPrincipal principal = System.Web.HttpContext.Current.Session["currentUser"] as CustomPrincipal;
            loggedInUser = principal == null ? null : principal.Customer as Customer;
        }

        [ConakryAuthorize]
        public ActionResult Index()
        {
            return View(loggedInUser);
        }

    }
}
