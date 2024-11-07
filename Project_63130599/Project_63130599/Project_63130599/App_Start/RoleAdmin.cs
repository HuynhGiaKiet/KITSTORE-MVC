﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63130599.App_Start
{
    public class RoleAdmin : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var Admin = SessionConfig.GetAdmin();
            if (Admin == null)
            {
                //filterContext.HttpContext.Session["ReturnUrlAdmin"] = filterContext.HttpContext.Request.Url.PathAndQuery;
                // Điều hướng về trang đăng nhập
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new
                    {
                        Controller = "Auth_63130599",
                        Action = "Login",
                        area = "Admin"
                    }));
                return;
            }

            return;
        }
    }
}