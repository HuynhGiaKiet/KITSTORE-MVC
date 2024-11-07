using Project_63130599.App_Start;
using Project_63130599.DATA;
using Project_63130599.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63130599.Controllers
{
    public class GioHang_63130599Controller : Controller
    {
        // GET: GioHang
        KhachHang user = SessionConfig.GetUser();
        [RoleUser]
        public ActionResult Index()
        {
            sdGioHang sd = new sdGioHang();
            var GioHang = sd.GetGioHang(user.Id);
            ViewBag.dsSP = sd.GetSanPhamGioHang(GioHang.Id);
            return View(GioHang);
        }

        [RoleUser]
        [HttpPost]
        public ActionResult ThemVaoGioHang(string idSP, int SoLuong)
        {
            sdGioHang sd = new sdGioHang();
            sd.ThemVaoGioHang(sd.GetGioHang(user.Id).Id, idSP, SoLuong);
            return RedirectToAction("Index");
        }

        [RoleUser]
        [HttpPost]
        public ActionResult XoaSanPham(string idSP)
        {
            sdGioHang sd = new sdGioHang();
            if (sd.XoaSanPham(sd.GetGioHang(user.Id).Id, idSP))
            {
                return RedirectToAction("Index");

            }
            return RedirectToAction("index", "home_63130599");

        }
    }
}