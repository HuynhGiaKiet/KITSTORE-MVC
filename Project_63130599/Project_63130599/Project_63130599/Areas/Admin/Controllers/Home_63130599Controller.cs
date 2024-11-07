using Project_63130599.DATA;
using Project_63130599.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63130599.Areas.Admin.Controllers
{
    public class Home_63130599Controller : Controller
    {
        int currentDate = Convert.ToInt32(DateTime.Now.Month);

        // GET: Admin/Home
        [RoleAdmin]
        public ActionResult Index(int thang = 0)
        {

            sdThongKe sdtk = new sdThongKe();
            if (thang == 0)
            {
                ViewBag.tk = sdtk.getThongKe(currentDate);
                ViewBag.thang = currentDate;
            }
            else
            {
                ViewBag.tk = sdtk.getThongKe(thang);
                ViewBag.thang = thang;
            }
            sdKhachHang sd = new sdKhachHang();
            var ds = sd.LoadDanhSach();
            return View(ds);
        }



        [RoleAdmin]
        public ActionResult Lich()
        {
            return View();
        }
    }
}