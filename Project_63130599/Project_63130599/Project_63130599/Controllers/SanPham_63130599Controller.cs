using Project_63130599.App_Start;
using Project_63130599.DATA;
using Project_63130599.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project_63130599.Controllers
{
    public class SanPham_63130599Controller : Controller
    {

        // GET: SanPham/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sdSanPham sd = new sdSanPham();
            var sp = sd.GetChiTiet(id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            ViewBag.sp = sd.GetDanhMuc(sp.IdDanhMuc).Where(m => m.Id != id).ToList();
            return View(sp);
        }

    }
}