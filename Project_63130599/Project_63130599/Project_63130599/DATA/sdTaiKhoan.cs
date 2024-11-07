using Project_63130599.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_63130599.DATA
{
    public class sdTaiKhoan
    {
        Project_63130599Entities db = new Project_63130599Entities();
        public TaiKhoanAdmin TimKiemAdmin(string username, string password)
        {
            var user = db.TaiKhoanAdmins.Where(m => m.TaiKhoan == username & m.MatKhau == password).ToList();
            if (user.Count > 0)
            {
                return user[0];
            }
            else
            {
                return null;
            }
        }

        public KhachHang TimKiemKhachHang(string username, string password)
        {
            var user = db.KhachHangs.Where(m => m.TaiKhoan == username & m.MatKhau == password).ToList();
            if (user.Count > 0)
            {
                return user[0];
            }
            else
            {
                return null;
            }
        }

        //Danh sach
        public List<KhachHang> DanhSach()
        {
            var users = db.KhachHangs.ToList();
            return users;
        }

        //Thêm mới
        public bool Themmoi(KhachHang kh)
        {
            if (db.KhachHangs.Any(x => x.TaiKhoan == kh.TaiKhoan))
            {
                return false;
            }
            string lastUserId = db.KhachHangs.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
            if(lastUserId == null)
            {
                lastUserId = "000";
            }
            int lastUserNumber = int.Parse(lastUserId.Substring(2)); // Lấy số sau "KH"
            int nextUserNumber = lastUserNumber + 1;
            string newUserId = "KH" + nextUserNumber.ToString("D3"); // "D3" đảm bảo rằng số được định dạng thành 3 chữ số, ví dụ: "KH006"
            kh.Id = newUserId;
            kh.NgaySinh = Convert.ToDateTime("2003-08-15");
            kh.GioiTinh = true;
            kh.DiaChi = " 2 Đ. Nguyễn Đình Chiểu, Vĩnh Thọ, Nha Trang, Khánh Hòa";
            kh.Sdt = "0948352623";

            kh.NgayTao = DateTime.Now;
            // thêm vào db
            db.KhachHangs.Add(kh);
            // lưu vào db
            db.SaveChanges();
            return true;

        }

        public bool CapNhatTaiKhoan(string id, KhachHang kh)
        {
            KhachHang user = db.KhachHangs.FirstOrDefault(m => m.Id == id);
            if (user != null)
            {
                user.Ho = kh.Ho;
                user.Ten = kh.Ten;
                user.GioiTinh = kh.GioiTinh;
                user.DiaChi = kh.DiaChi;
                user.Sdt = kh.Sdt;
                user.NgaySinh = kh.NgaySinh;
                db.SaveChanges(); // Lưu các thay đổi vào cơ sở dữ liệu
                return true;
            }

            return false;
        }
    }
}