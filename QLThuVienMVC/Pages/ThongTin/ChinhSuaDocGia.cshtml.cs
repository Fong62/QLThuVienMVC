using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLThuVienMVC.Models;

namespace QLThuVienMVC.Pages.ThongTin
{
    public class ChinhSuaDocGiaModel : PageModel
    {
        private readonly InterfaceThongTin _thongTinRepo;

        public ChinhSuaDocGiaModel(InterfaceThongTin thongTinRepo)
        {
            _thongTinRepo = thongTinRepo;
        }

        [BindProperty]
        public QLThuVienMVC.Models.DocGia DocGia { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToPage("/Account/Login");
            }

            DocGia = await _thongTinRepo.LayDocGiaByUserName(userName);

            if (DocGia == null)
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

                // Load existing data first
                var existingDocGia = await _thongTinRepo.LayDocGiaByUserName(userName);

                if (existingDocGia == null)
                {
                    return NotFound();
                }

                // Update only allowed fields
                existingDocGia.HoTen = DocGia.HoTen;
                existingDocGia.NgaySinh = DocGia.NgaySinh;
                existingDocGia.DiaChi = DocGia.DiaChi;
                existingDocGia.Email = DocGia.Email;

                // Update user info if exists
                if (existingDocGia.User != null && DocGia.User != null)
                {
                    existingDocGia.User.Email = DocGia.User.Email;
                    existingDocGia.User.PhoneNumber = DocGia.User.PhoneNumber;
                }

                await _thongTinRepo.UpdateDocGia(existingDocGia);

                TempData["Success"] = "Cập nhật thông tin thành công!";
                return Page(); 
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi cập nhật: {ex.Message}");
                // Log the exception here
                return Page();
            }
        }
    }
}
