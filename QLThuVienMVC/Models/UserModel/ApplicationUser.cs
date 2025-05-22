using Microsoft.AspNetCore.Identity;
using QLThuVienMVC.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLThuVienMVC.Models.UserModel
{
    public class ApplicationUser : IdentityUser
    {
        public string? MaDocGia { get; set; }

        public string? MaNhanVien { get; set; }

        public DocGia? DocGia { get; set; }
        public NhanVien? NhanVien { get; set; }
    }
}
