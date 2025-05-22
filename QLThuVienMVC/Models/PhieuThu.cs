using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLThuVienMVC.Models
{
    public class PhieuThu
    {
        [Key]
        public string MaPhieuThu { get; set; }

        [ForeignKey("NhanVien")]
        public string? MaNhanVien { get; set; }
        public NhanVien? NhanVien { get; set; }
        public decimal? TienNo { get; set; }
        public decimal? SoTienThu { get; set; }

        [ForeignKey("DocGia")]
        public string MaDocGia { get; set; }
        public DocGia DocGia { get; set; }
        
    }
}
