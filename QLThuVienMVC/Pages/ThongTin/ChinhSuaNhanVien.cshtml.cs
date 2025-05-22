using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLThuVienMVC.Models;

namespace QLThuVienMVC.Pages.ThongTin
{
    public class ChinhSuaNhanVienModel : PageModel
    {
        private readonly InterfaceThongTin _thongTinRepo;

        public ChinhSuaNhanVienModel(InterfaceThongTin thongTinRepo)
        {
            _thongTinRepo = thongTinRepo;
        }

        [BindProperty]
        public QLThuVienMVC.Models.NhanVien NhanVien { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToPage("/Account/Login");
            }

            NhanVien = await _thongTinRepo.LayNhanVienByUserName(userName);

            if (NhanVien == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var userName = User.Identity?.Name;
                if (string.IsNullOrEmpty(userName))
                {
                    return RedirectToPage("/Account/Login");
                }

                var existingNhanVien = await _thongTinRepo.LayNhanVienByUserName(userName);

                if (existingNhanVien == null)
                {
                    return NotFound();
                }

                // Cập nhật các trường thông tin
                existingNhanVien.HoTen = NhanVien.HoTen;
                existingNhanVien.NgaySinh = NhanVien.NgaySinh;
                existingNhanVien.DiaChi = NhanVien.DiaChi;
                existingNhanVien.SoDienThoai = NhanVien.SoDienThoai;
                existingNhanVien.BangCap = NhanVien.BangCap;

                // Cập nhật thông tin user nếu có
                if (existingNhanVien.User != null && NhanVien.User != null)
                {
                    existingNhanVien.User.Email = NhanVien.User.Email;
                    existingNhanVien.User.PhoneNumber = NhanVien.User.PhoneNumber;
                }

                await _thongTinRepo.UpdateNhanVien(existingNhanVien);
                TempData["Success"] = "Cập nhật thông tin nhân viên thành công!";
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi cập nhật: {ex.Message}");
                // Ghi log lỗi ở đây
                return Page();
            }
        }
    }
}