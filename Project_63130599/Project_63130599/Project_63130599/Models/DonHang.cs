//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_63130599.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            this.SanPhamDonHangs = new HashSet<SanPhamDonHang>();
        }
    
        public string Id { get; set; }
        public string IdKH { get; set; }
        public string IdPT { get; set; }
        public string Ten { get; set; }
        public string TrangThai { get; set; }
        public string DienThoai { get; set; }
        public string GhiChuDonHang { get; set; }
        public string DiaChi { get; set; }
        public Nullable<decimal> TongTienThanhToan { get; set; }
        public Nullable<System.DateTime> NgayTaoDon { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        public virtual PhuongThuc PhuongThuc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPhamDonHang> SanPhamDonHangs { get; set; }
    }
}
