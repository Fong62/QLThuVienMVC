using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLThuVienMVC.Models
{
    public class ThanhLySach
    {
        [Key]
        public string MaThanhLy { get; set; }
        public DateTime? NgayThanhLy { get; set; }
        public string LyDoThanhLy { get; set; }

        [ForeignKey("Sach")]
        public string MaSach { get; set; }
        public Sach? Sach { get; set; }

        [ForeignKey("NhanVien")]
        public string MaNhanVien { get; set; }
        public NhanVien? NhanVien { get; set; }
    }
}
