using Project_63130599.DATA;
using Project_63130599.App_Start;
using Project_63130599.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63130599.Areas.Admin.Controllers
{
    public class SanPham_63130599Controller : Controller
    {
        // GET: Admin/Product
        [RoleAdmin]

        public ActionResult DanhSach()
        {

            var sd = new sdSanPham();
            var sp = sd.LoadDanhSach();
            return View(sp.OrderBy(m => m.NgayNhap));
        }

        [RoleAdmin]
        public ActionResult ThemMoi()
        {

            return View();
        }

        [RoleAdmin]
        [HttpPost]
        public ActionResult ThemMoi(SanPham sp, HttpPostedFileBase fileUpload)
        {

            var sd = new sdSanPham();
            if (fileUpload != null)
            {
                if (fileUpload.ContentLength > 0)
                {
                    // lưu 
                    // 1. xác định thư mục lưu: assets\imgs\product\
                    string folder = "/images/";
                    // 2. xác định tên file
                    string fileName = fileUpload.FileName;
                    // 3. xác định đường dẫn tuyệt đối của file
                    string pathAbsolute = Server.MapPath(folder + fileName);
                    // 4. Kiêm tra tồn tại file có tồn tại file cũ
                    // xóa
                    //if(System.IO.File.Exists(pathAbsolute) == true)
                    //{
                    //	System.IO.File.Delete(pathAbsolute);
                    //}
                    // tăng đuôi thêm 1
                    int i = 0;
                    string name = Path.GetFileNameWithoutExtension(fileName);
                    string ext = Path.GetExtension(fileName);
                    while (System.IO.File.Exists(pathAbsolute) == true)
                    {
                        i++;

                        fileName = name + "_" + i + ext;
                        pathAbsolute = Server.MapPath(folder + fileName);
                    }

                    // 5. Lưu
                    fileUpload.SaveAs(pathAbsolute);
                    sp.Anh = folder + fileName;
                }
            }

            sd.ThemMoi(sp);
            return Redirect("danhsach");
        }

        [RoleAdmin]
        public ActionResult Xoa(string Id)
        {

            var sd = new sdSanPham();
            var sp = sd.GetChiTiet(Id);
            return View(sp);
        }

        [RoleAdmin]
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(string Id)
        {

            var sd = new sdSanPham();
            sd.Xoa(Id);
            return RedirectToAction("danhsach");
        }

        [RoleAdmin]
        public ActionResult CapNhat(string Id)
        {


            var sp = new sdSanPham().GetChiTiet(Id);
            return View(sp);
        }

        [RoleAdmin]
        [HttpPost]
        public ActionResult CapNhat(SanPham sp, HttpPostedFileBase fileUpload)
        {

            var sd = new sdSanPham();

            // 1.Kiểm tra tồn tại: người dùng có đưa file lên không ( check null, length)
            if (fileUpload != null)
            {
                if (fileUpload.ContentLength > 0)
                {
                    // lưu 
                    // 1. xác định thư mục lưu: assets\imgs\product\
                    string folder = "/images/product/";
                    // 2. xác định tên file
                    string fileName = fileUpload.FileName;
                    // 3. xác định đường dẫn tuyệt đối của file
                    string pathAbsolute = Server.MapPath(folder + fileName);
                    // 4. Kiêm tra tồn tại file có tồn tại file cũ
                    // xóa
                    //if(System.IO.File.Exists(pathAbsolute) == true)
                    //{
                    //	System.IO.File.Delete(pathAbsolute);
                    //}
                    // tăng đuôi thêm 1
                    int i = 0;
                    string name = Path.GetFileNameWithoutExtension(fileName);
                    string ext = Path.GetExtension(fileName);
                    while (System.IO.File.Exists(pathAbsolute) == true)
                    {
                        i++;

                        fileName = name + "_" + i + ext;
                        pathAbsolute = Server.MapPath(folder + fileName);
                    }

                    // 5. Lưu
                    fileUpload.SaveAs(pathAbsolute);
                    sp.Anh = folder + fileName;
                }
            }
            if (sd.CapNhat(sp) == true)
            {
                return RedirectToAction("danhsach");
            }
            else
            {
                return View(sp);
            }
        }
    }
}