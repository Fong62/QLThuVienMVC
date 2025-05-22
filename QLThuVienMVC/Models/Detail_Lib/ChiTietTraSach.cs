using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLThuVienMVC.Models.Detail_Lib
{
    public class ChiTietTraSach
    {
        [Key]
        public string MaSach { get; set; }

        [Key]
        public string MaPhieuTra { get; set; }
        public DateTime? NgayTraThucTe { get; set; }
        public int? SoNgayTre { get; set; }
        public string TinhTrangTra { get; set; }

        [ForeignKey("MaSach")]
        public Sach Sach { get; set; }

        [ForeignKey("MaPhieuTra")]
        public PhieuTraSach PhieuTraSach { get; set; }
    }
}
