using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using QLThuVienMVC.Models.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using QLThuVienMVC.Models;
using System.Dynamic;

namespace QLThuVienMVC.Pages.ThongTin
{
    [Authorize]
    public class ThongTinModel : PageModel
    {
        private readonly InterfaceThongTin _thongTinRepo;
        private readonly InterfaceSach _sachRepo;

        public ThongTinModel(InterfaceThongTin thongTinRepo, InterfaceSach sachRepo)
        {
            _thongTinRepo = thongTinRepo;
            _sachRepo = sachRepo;
        }

        public QLThuVienMVC.Models.DocGia? CurrentDocGia { get; set; }
        public QLThuVienMVC.Models.NhanVien? CurrentNhanVien { get; set; }
        public QLThuVienMVC.Models.Sach? CurrentSach { get; set; }
        public async Task<IActionResult> OnGetAsync(string? id)
        {
          
            if (!string.IsNullOrWhiteSpace(id))
            {
                CurrentSach = await _sachRepo.LaySachTheoId(id);
                if (CurrentSach == null)
                {
                    TempData["ErrorMessage"] = "Không tìm thấy sách!";
                }
                return Page();
            }

            
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToPage("/Account/Login");
            }

            CurrentDocGia = await _thongTinRepo.LayDocGiaByUserName(userName);
            if (CurrentDocGia == null)
            {
                CurrentNhanVien = await _thongTinRepo.LayNhanVienByUserName(userName);
            }

            if (CurrentDocGia == null && CurrentNhanVien == null)
            {
                TempData["ErrorMessage"] = "Không có thông tin!";
            }

            return Page();
        }
    }
}