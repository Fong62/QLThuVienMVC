using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLThuVienMVC.Models
{
    public class NhaCungCap
    {
        [Key]
        public string MaNhaCungCap { get; set; }
        public string? TenNhaCungCap { get; set; }
        public string? DiaChi { get; set; }
        public int? SoDienThoai { get; set; }
        public string? Email { get; set; }

        public ICollection<Sach>? Sach { get; set; }
        public ICollection<PhieuCungCap>? PhieuCungCap { get; set; }
    }
}
