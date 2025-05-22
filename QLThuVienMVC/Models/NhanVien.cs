using QLThuVienMVC.Models.UserModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLThuVienMVC.Models
{
    public class NhanVien
    {
        [Key]
        public string? MaNhanVien { get; set; }
        public string? HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public int? SoDienThoai { get; set; }
        public string? BangCap { get; set; }
        public string? BoPhan { get; set; }
        public string? ChucVu { get; set; }

        public ICollection<BaoCao>? BaoCao { get; set; }
        public ICollection<DocGia>? DocGia{ get; set; }
        public ICollection<PhieuCungCap>? PhieuCungCap { get; set; }
        public ICollection<PhieuMuonSach>? PhieuMuonSach { get; set; }
        public ICollection<PhieuTraSach>? PhieuTraSach { get; set; }
        public ICollection<PhieuThu>? PhieuThu { get; set; }
        public ICollection<ThanhLySach>? ThanhLySach { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
