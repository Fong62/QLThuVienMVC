using QLThuVienMVC.Models.Detail_Lib;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLThuVienMVC.Models
{
    public class Sach
    {
        [Key]
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public string TheLoai { get; set; }
        public DateTime? NamXuatBan { get; set; }
        public string NhaXuatBan { get; set; }
        public DateTime? NgayNhap { get; set; }
        public decimal? GiaTri { get; set; }
        public string TinhTrang { get; set; }
        public string coverUrl { get; set; }

        [ForeignKey("NhaCungCap")]
        public string MaNhaCungCap { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        public ICollection<ChiTietCungCap>? ChiTietCungCap { get; set; }
        public ICollection<ChiTietMuonSach>? ChiTietMuonSach { get; set; }
        public ICollection<ChiTietTraSach>? ChiTietTraSach { get; set; }
        public ThanhLySach? ThanhLySach { get; set; }
    }
}
