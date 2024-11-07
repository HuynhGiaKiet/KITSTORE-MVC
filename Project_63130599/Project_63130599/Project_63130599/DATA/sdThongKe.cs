using Project_63130599.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_63130599.DATA
{
    public class sdThongKe
    {
        Project_63130599Entities db = new Project_63130599Entities();
        public ThongKe getThongKe(int thang)
        {
            var thongKe = new ThongKe();
            thongKe.tongDoanhThu = (decimal)db.DonHangs.Where(m => m.NgayTaoDon.Value.Month == thang).ToList().Sum(m => m.TongTienThanhToan);
            thongKe.tongNguoiDung = db.KhachHangs.Count();
            thongKe.nguoiDungMoi = db.KhachHangs.Where(m => m.NgayTao.Value.Month == thang).ToList().Count;
            thongKe.tongDonHang = db.DonHangs.Where(m => m.NgayTaoDon.Value.Month == thang).ToList().Count;
            thongKe.tongDonHangDaGiao = db.DonHangs.Where(m => m.NgayTaoDon.Value.Month == thang && m.TrangThai == "Đã giao").ToList().Count;
            thongKe.sanPhamDaNhap = db.SanPhams.Where(m => m.NgayNhap.Value.Month == thang).ToList().Count;
            return thongKe;
        }
    }
}