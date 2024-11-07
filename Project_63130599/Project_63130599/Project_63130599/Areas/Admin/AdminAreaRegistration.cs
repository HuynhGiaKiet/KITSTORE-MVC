using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63130599.Areas.Admin
{
	public class AdminAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "Admin";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				 "Admin_default",
				"Admin/{controller}/{action}/{id}",
				new { action = "Index", Controller = "Home_63130599", id = UrlParameter.Optional },
				new[] { "Project_63130599.Areas.Admin.Controllers" }
			);
		}
	}
}