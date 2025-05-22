using QLThuVienMVC.Models.Detail_Lib;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLThuVienMVC.Models
{
    public class PhieuMuonSach
    {
        [Key]
        public string MaPhieuMuon { get; set; }
        public DateTime? NgayMuon { get; set; }

        [ForeignKey("NhanVien")]
        public string? MaNhanVien { get; set; }
        public NhanVien? NhanVien { get; set; }

        [ForeignKey("DocGia")]
        public string? MaDocGia { get; set; }
        public DocGia? DocGia { get; set; }
        public ICollection<ChiTietMuonSach>? ChiTietMuonSach { get; set; }
    }
}
