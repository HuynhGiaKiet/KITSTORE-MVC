using Project_63130599.DATA;
using Project_63130599.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63130599.Areas.Admin.Controllers
{
    public class Auth_63130599Controller : Controller
    {
        // GET: Admin/Auth
        public ActionResult Login()
        {
            var admin = SessionConfig.GetAdmin();
            if (admin != null)
            {
                return RedirectToAction("Index", "Home_63130599");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string returnUrl = Session["ReturnUrlAdmin"] as string;
            sdTaiKhoan sd = new sdTaiKhoan();
            var user = sd.TimKiemAdmin(username, password);
            if (user != null)
            {
                SessionConfig.SetAdmin(user);
                //if (!string.IsNullOrEmpty(returnUrl))
                //{
                //	// Clear the stored return URL from the session
                //	Session.Remove("ReturnUrlAdmin");
                //	//if(returnUrl == "https://localhost:44310/GioHang/ThemVaoGioHang")
                //	//{
                //	//	return Redirect("index");

                //	//}
                //	return Redirect(returnUrl);
                //}
                //else
                //{
                //	return RedirectToAction("Index", "Home", new { area = "Admin" });
                //	//return Redirect("/Admin/home/index");
                //}
                return RedirectToAction("Index", "Home_63130599", new { area = "Admin" });

            }
            ViewBag.error = "Tên đăng nhập hoặc mật khẩu không đúng";
            return View();
        }

        public ActionResult Logout()
        {
            SessionConfig.SetAdmin(null);
            return RedirectToAction("Login", "Auth_63130599");
        }
    }
}