using QLThuVienMVC.Models.UserModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLThuVienMVC.Models
{
    public class DocGia
    {
        [Key]
        public string MaDocGia { get; set; }

        [ForeignKey("NhanVien")]
        public string? MaNhanVien { get; set; }
        public NhanVien? NhanVien { get; set; }

        public string? HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public string? Email { get; set; }
        public string? LoaiDocGia { get; set; }
        public DateTime? NgayLapThe { get; set; }

        public ICollection<PhieuMuonSach>? PhieuMuonSach { get; set; }
        public ICollection<PhieuTraSach>? PhieuTraSach { get; set; }
        public ICollection<PhieuThu>? PhieuThu { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
