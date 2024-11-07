using Project_63130599.DATA;
using Project_63130599.Models;
using Project_63130599.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63130599.Controllers
{
    public class TaiKhoan_63130599Controller : Controller
    {
        // GET: TaiKhoan
        [RoleUser]
        public ActionResult Setting()
        {
            sdKhachHang sd = new sdKhachHang();
            var user = SessionConfig.GetUser();
            return View(sd.GetChiTiet(user.Id));
        }

        [RoleUser]
        [HttpPost]
        public ActionResult Setting(string ho, string ten, string diaChi, string tp, string tinh, string quocGia, bool gioiTinh, string sdt, DateTime ngaySinh)
        {
            sdKhachHang sd = new sdKhachHang();
            sdTaiKhoan sdtk = new sdTaiKhoan();
            var user = SessionConfig.GetUser();
            var userCurrent = sd.GetChiTiet(user.Id);
            userCurrent.Ho = ho;
            userCurrent.Ten = ten;
            userCurrent.DiaChi = diaChi + ", " + tp + ", " + tinh + ", " + quocGia;
            userCurrent.GioiTinh = gioiTinh;
            userCurrent.Sdt = sdt;
            userCurrent.Sdt = sdt;
            userCurrent.NgaySinh = ngaySinh;
            sdtk.CapNhatTaiKhoan(user.Id, userCurrent);
            return View(userCurrent);
        }
    }
}