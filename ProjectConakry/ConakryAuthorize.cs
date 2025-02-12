﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;
namespace ProjectConakry.Web.Ariya
{
    public class ConakryAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = System.Web.HttpContext.Current.Session != null &&
                                System.Web.HttpContext.Current.Session["currentUser"] != null;
            if (!isAuthorized)
            {
                return false;
            }

            return true;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            System.Web.HttpContext.Current.Session["redirectPath"] = System.Web.HttpContext.Current.Request.Url.ToString();
            filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "LogIn",
                                action = "Index"
                                
                            })
                        );
         
        }
    }
}