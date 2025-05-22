using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLThuVienMVC.Models
{
    public class BaoCao
    {
        [Key]
        public string MaBaoCao { get; set; }

        [ForeignKey("NhanVien")]
        public string MaNhanVien { get; set; }
        public NhanVien NhanVien { get; set; }

        public string LoaiBaoCao { get; set; }
        public DateTime? NgayBaoCao { get; set; }

    }
}
