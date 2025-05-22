using Microsoft.EntityFrameworkCore;
using QLThuVienMVC.Models.Detail_Lib;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLThuVienMVC.Models
{
    public class PhieuTraSach
    {
        [Key]
        public string MaPhieuTra { get; set; }

        [ForeignKey("NhanVien")]
        public string? MaNhanVien { get; set; }
        public NhanVien? NhanVien { get; set; }
        public DateTime? NgayTra { get; set; }
        public decimal? TienPhat { get; set; }

        [ForeignKey("DocGia")]
        public string MaDocGia { get; set; }
        public DocGia DocGia { get; set; }
        
        public ICollection<ChiTietTraSach> ChiTietTraSach { get; set; }
    }
}
