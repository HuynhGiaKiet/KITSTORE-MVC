using Project_63130599.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_63130599.DATA
{
    public class ThongKe
    {
        public decimal tongDoanhThu { get; set; }
        public int tongNguoiDung { get; set; }
        public int nguoiDungMoi { get; set; }
        public int tongDonHang { get; set; }
        public int tongDonHangDaGiao { get; set; }
        public int sanPhamDaNhap { get; set; }
        public int thangThongKe { get; set; }
        public List<SanPham> sanPhamPhoBien { get; set; }

    }
}