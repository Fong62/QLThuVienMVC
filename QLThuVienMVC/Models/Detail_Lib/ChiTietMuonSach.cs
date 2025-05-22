using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLThuVienMVC.Models.Detail_Lib
{
    public class ChiTietMuonSach
    {
        [Key]
        public string MaPhieuMuon { get; set; }

        [Key]
        public string MaSach { get; set; }
        public DateTime? NgayPhaiTra { get; set; }
        public string TinhTrangMuon { get; set; }

        [ForeignKey("MaPhieuMuon")]
        public PhieuMuonSach PhieuMuonSach { get; set; }

        [ForeignKey("MaSach")]
        public Sach Sach { get; set; }
    }
}
