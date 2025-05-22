using Microsoft.EntityFrameworkCore;
using QLThuVienMVC.Models.Detail_Lib;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLThuVienMVC.Models
{
    public class PhieuCungCap
    {
        [Key]
        public string MaPhieuCungCap { get; set; }
        public DateTime? NgayNhap { get; set; }
        public decimal? TongGiaTri { get; set; }

        [ForeignKey("NhanVien")]
        public string? MaNhanVien { get; set; }
        public NhanVien? NhanVien { get; set; }

        [ForeignKey("NhaCungCap")]
        public string? MaNhaCungCap { get; set; }
        public NhaCungCap? NhaCungCap { get; set; }
        public ICollection<ChiTietCungCap>? ChiTietCungCap { get; set; }
    }
}
