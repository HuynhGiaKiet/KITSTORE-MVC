using Project_63130599.DATA;
using Project_63130599.App_Start;
using Project_63130599.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace Project_63130599.Controllers
{
    public class DonHang_63130599Controller : Controller
    {
        // GET: DonHang
        KhachHang user = SessionConfig.GetUser();
        [RoleUser]
        public ActionResult Index()
        {
            sdDonHang sd = new sdDonHang();
            return View(sd.DanhSach().Where(m => m.IdKH == user.Id).ToList());
        }

        // GET: DonHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sdDonHang sd = new sdDonHang();
            var dh = sd.GetChiTiet(id);
            if (dh == null)
            {
                return HttpNotFound();
            }
            return View(dh);
        }
    }
}