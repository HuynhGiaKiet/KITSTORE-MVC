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
    public class Home_63130599Controller : Controller
    {
        public ActionResult Index()
        {
            sdSanPham sd = new sdSanPham();
            return View(sd.LoadDanhSach());
        }
        public ActionResult Login()
        {
            var userSS = SessionConfig.GetUser();
            if (userSS != null)
            {
                return RedirectToAction("Index", "Home_63130599");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string returnUrl = Session["ReturnUrlUser"] as string;
            var userSS = SessionConfig.GetUser();


            if (userSS != null)
            {
                //if (!string.IsNullOrEmpty(returnUrl))
                //{
                //	// Clear the stored return URL from the session
                //	Session.Remove("ReturnUrlUser");
                //	return Redirect(returnUrl);
                //}
                //else
                //{
                //	return RedirectToAction("index", "Home");
                //	//return Redirect("/home/index");
                //}
                return RedirectToAction("Index", "Home_63130599");
            }
            sdTaiKhoan sd = new sdTaiKhoan();
            var user = sd.TimKiemKhachHang(username, password);
            if (user != null)
            {
                SessionConfig.SetUser(user);
                //if (!string.IsNullOrEmpty(returnUrl))
                //{
                //	// Clear the stored return URL from the session
                //	Session.Remove("ReturnUrlUser");
                //	return Redirect(returnUrl);
                //}
                //else
                //{
                //	return RedirectToAction("index", "Home");
                //	//return Redirect("/home/index");
                //}
                return RedirectToAction("index", "Home_63130599");
            }
            ViewBag.error = "Tên đăng nhập hoặc mật khẩu không đúng";
            ViewBag.username = username;
            return View();
        }

        public ActionResult Register()
        {
            var userSS = SessionConfig.GetUser();
            if (userSS != null)
            {
                return RedirectToAction("Index", "Home_63130599");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(KhachHang kh)
        {
            var userSS = SessionConfig.GetUser();
            if (userSS != null)
            {
                return RedirectToAction("Index", "Home_63130599");
            }
            ViewBag.Ho = kh.Ho;
            ViewBag.Ten = kh.Ten;
            ViewBag.TaiKhoan = kh.TaiKhoan;
            ViewBag.MatKhau = kh.MatKhau;
            sdTaiKhoan sd = new sdTaiKhoan();
            if (sd.Themmoi(kh) == true)
            {
                return RedirectToAction("login");
            }
            else
            {
                ViewBag.error = "Email đã tồn tại trong hệ thống!";
                return View(kh);
            }
        }
        public ActionResult Logout()
        {
            SessionConfig.SetUser(null);
            return RedirectToAction("Login", "Home_63130599");
        }
        public ActionResult TimKiem(string TuKhoa)
        {
            sdSanPham sd = new sdSanPham();
            List<SanPham> ketqua = new List<SanPham>();

            if (!string.IsNullOrEmpty(TuKhoa))
            {
                ketqua = sd.LoadDanhSach().Where(m => m.TenSP.ToLower().Contains(TuKhoa.ToLower())).ToList();
            }

            ViewBag.TuKhoa = TuKhoa;

            if (ketqua.Count == 0)
            {
                ViewBag.noti = "Không có kết quả phù hợp với từ khóa " + "\"" + TuKhoa + "\"";
            }
            return View(ketqua);
        }

        public ActionResult DanhMuc(string idDanhMuc)
        {
            sdDanhMuc sd = new sdDanhMuc();
            sdSanPham sdSP = new sdSanPham();
            ViewBag.danhMuc = sd.LoadDanhSach();
            ViewBag.luachon = idDanhMuc;
            if (string.IsNullOrEmpty(idDanhMuc))
            {
                return View(sdSP.LoadDanhSach());

            }
            else
            {
                return View(sdSP.LoadDanhSach().Where(m => m.IdDanhMuc == idDanhMuc).ToList());
            }
        }


    }
}