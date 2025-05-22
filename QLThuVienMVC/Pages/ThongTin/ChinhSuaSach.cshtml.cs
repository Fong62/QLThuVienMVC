using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLThuVienMVC.Models;

namespace QLThuVienMVC.Pages.ThongTin
{
    [Authorize(Roles ="Admin")]
    public class ChinhSuaSachModel : PageModel
    {
        private readonly InterfaceSach repoSach;
        public readonly LibDataContext context;

        public ChinhSuaSachModel(InterfaceSach repoSach, LibDataContext context)
        {
            this.repoSach = repoSach;
            this.context = context;
        }

        [BindProperty]
        public QLThuVienMVC.Models.Sach Sach { get; set; }
        public async Task<IActionResult> OnGet(string? id)
        {
            Sach = await repoSach.LaySachTheoId(id);
            if (Sach == null)
            {
                TempData["Error"] = "Không thấy sách";
            }
            
           
            return Page();
        }
        public async Task<IActionResult> OnPostUpdate()
        {
            ModelState.Remove("Sach.NhaCungCap");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var existingSach = await repoSach.LaySachTheoId(Sach.MaSach);
                if (existingSach == null)
                {
                    TempData["Error"] = "Không tìm thấy sách cần cập nhật.";
                    return Page();
                }

                existingSach.TenSach = Sach.TenSach;
                existingSach.TacGia = Sach.TacGia;
                existingSach.TheLoai = Sach.TheLoai;
                existingSach.NamXuatBan = Sach.NamXuatBan;
                existingSach.NhaXuatBan = Sach.NhaXuatBan;
                existingSach.NgayNhap = Sach.NgayNhap;
                existingSach.GiaTri = Sach.GiaTri;
                existingSach.TinhTrang = Sach.TinhTrang;
                existingSach.coverUrl = Sach.coverUrl;

                await context.SaveChangesAsync();
              
                TempData["Success"] = "Cập nhật thông tin sách thành công!";
                return Page();
               
                    
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi khi cập nhật: {ex.Message}");
                return Page();
            }
        }
    }
}
