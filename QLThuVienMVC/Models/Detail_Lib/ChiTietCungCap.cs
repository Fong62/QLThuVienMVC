using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLThuVienMVC.Models.Detail_Lib
{
    public class ChiTietCungCap
    {
        [Key]
        public string MaPhieuCungCap { get; set; }

        [Key]
        public string MaSach { get; set; }
        public int? SoLuong { get; set; }
        public decimal? Gia { get; set; }

        [ForeignKey("MaPhieuCungCap")]
        public PhieuCungCap PhieuCungCap { get; set; }

        [ForeignKey("MaSach")]
        public Sach Sach { get; set; }
    }
}
