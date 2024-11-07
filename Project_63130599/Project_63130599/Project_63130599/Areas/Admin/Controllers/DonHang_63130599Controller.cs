using Project_63130599.DATA;
using Project_63130599.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63130599.Areas.Admin.Controllers
{
    public class DonHang_63130599Controller : Controller
    {
        // GET: Admin/DonHang
        [RoleAdmin]
        public ActionResult DanhSach(string selected)
        {
            sdDonHang sd = new sdDonHang();
            var ds = sd.DanhSach();
            ViewBag.Selected = selected;
            if (!string.IsNullOrEmpty(selected))
            {

                ds = ds.Where(x => x.TrangThai == selected).ToList();
                ViewBag.count = ds.Count;
                return View(ds);

            }
            return View(ds);
        }



        [RoleAdmin]
        public ActionResult ChiTietDonHang(string id)
        {
            sdDonHang sd = new sdDonHang();

            return View(sd.GetChiTiet(id));
        }

        [RoleAdmin]
        public ActionResult XoaDonHang()
        {
            return View();
        }

        [RoleAdmin]
        [HttpPost]
        public ActionResult XoaDonHang(string id)
        {
            sdDonHang sd = new sdDonHang();
            sd.XoaDonHang(id);
            return RedirectToAction("Danhsach", "donhang_63130599");
        }

        [RoleAdmin]
        public ActionResult XacNhanGiao(string id)
        {
            sdDonHang sd = new sdDonHang();
            sd.SetTrangThaiDonHang(id);
            return Redirect("/admin/DonHang_63130599/danhsach");
        }
    }
}