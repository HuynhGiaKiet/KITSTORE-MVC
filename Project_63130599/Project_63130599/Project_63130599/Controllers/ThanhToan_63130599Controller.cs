using Project_63130599.DATA;
using Project_63130599.App_Start;
using Project_63130599.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63130599.Controllers
{
    public class ThanhToan_63130599Controller : Controller
    {
        KhachHang user = SessionConfig.GetUser();
        // GET: ThanhToan

        [RoleUser]
        public ActionResult Buoc1(string GhiChuDonHang)
        {
            sdKhachHang sd = new sdKhachHang();
            sdGioHang sdGH = new sdGioHang();
            var kh = sd.GetChiTiet(user.Id);
            ViewBag.dsSP = sdGH.GetSanPhamGioHang(sdGH.GetGioHang(kh.Id).Id);
            ViewBag.Tong = sdGH.GetGioHang(user.Id).TongTien;
            ViewBag.GhiChuDonHang = GhiChuDonHang;
            return View(kh);
        }

        [RoleUser]
        [HttpPost]
        public ActionResult Buoc1(DonHang model)
        {

            return RedirectToAction("Buoc2", model);
        }

        [RoleUser]
        public ActionResult Buoc2()
        {
            sdKhachHang sd = new sdKhachHang();
            sdGioHang sdGH = new sdGioHang();
            sdDonHang sdDH = new sdDonHang();
            var kh = sd.GetChiTiet(user.Id);
            ViewBag.PT = sdDH.GetPhuongThuc();
            ViewBag.dsSP = sdGH.GetSanPhamGioHang(sdGH.GetGioHang(kh.Id).Id);
            ViewBag.Tong = sdGH.GetGioHang(user.Id).TongTien;
            return View();
        }

        [RoleUser]
        [HttpPost]
        public ActionResult Buoc2(string idPT, DonHang model)
        {
            sdKhachHang sd = new sdKhachHang();
            sdGioHang sdGH = new sdGioHang();
            sdDonHang sdDH = new sdDonHang();
            sdDH.ThemDonHang(user.Id, sdGH.GetGioHang(user.Id).Id, idPT, model.DienThoai, model.Ten, model.GhiChuDonHang, model.DiaChi);
            return RedirectToAction("ThanhToanThanhCong");
        }

        [RoleUser]
        public ActionResult ThanhToanThanhCong()
        {
            return View();
        }
    }
}