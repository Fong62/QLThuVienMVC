using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLThuVienMVC.Models;
using QLThuVienMVC.Models.Detail_Lib;
using QLThuVienMVC.Models.UserModel;

namespace QLThuVienMVC.Pages.NhanVien
{
    [Authorize(Roles = "NhanVien")]
    public class XacNhanTraSachModel : PageModel
    {
        private readonly InterfaceSach _repo;

        public XacNhanTraSachModel(InterfaceSach repo)
        {
            _repo = repo;
        }

        public List<ChiTietMuonSach> dsct = new List<ChiTietMuonSach>();

        [BindProperty]
        public string MaDocGia { get; set; }

        [BindProperty]
        public List<string> SachDuocChon { get; set; } = new List<string>();

        [BindProperty]
        public List<string> TinhTrangSach { get; set; } = new List<string>();

        public string LayMa()
        {
            var userManager = HttpContext.RequestServices.GetService<UserManager<ApplicationUser>>();
            var user = userManager?.GetUserAsync(User).Result;

            if (user != null)
            {
                if (userManager.IsInRoleAsync(user, "NhanVien").Result)
                    return user.MaNhanVien;
            }
            return null;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostTimDG(string? MaDocGia)
        {
            //this.MaDocGia = MaDocGia.Trim();
            dsct = await _repo.LayPCThieuMuonDaDuyet(this.MaDocGia);
            return Page();
        }

        public async Task<IActionResult> OnPostXacNhanTra()
        {
            string maNV = LayMa();

            if (SachDuocChon.Count == 0 || TinhTrangSach.Count == 0 || SachDuocChon.Count != TinhTrangSach.Count)
            {
                TempData["Error"] = "Vui lòng chọn sách và tình trạng sách hợp lệ.";
                dsct = await _repo.LayPCThieuMuonDaDuyet(MaDocGia);
                return Page();
            }

            
            bool result = await _repo.ThemPhieuTra(MaDocGia, SachDuocChon, TinhTrangSach, maNV);

            if (result)
            {
                TempData["Success"] = "✅ Đã xác nhận trả sách thành công.";

               
                var danhSachHienTai = await _repo.LayPCThieuMuonDaDuyet(MaDocGia);
                dsct = danhSachHienTai.Where(ct => !SachDuocChon.Contains(ct.MaSach)).ToList();

                return Page(); 
            }
            else
            {
                TempData["Error"] = "❌ Xác nhận trả sách thất bại.";
                dsct = await _repo.LayPCThieuMuonDaDuyet(MaDocGia);
                return Page();
            }
        }
    }
}

