using System.Security.AccessControl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLThuVienMVC.Models;
using QLThuVienMVC.Models.Detail_Lib;
using QLThuVienMVC.Models.UserModel;

namespace QLThuVienMVC.Pages.NhanVien
{
    [Authorize(Roles ="NhanVien")]
    public class XacNhanMuonSachModel : PageModel
    {
        private InterfaceSach _repo;
        
        public XacNhanMuonSachModel(InterfaceSach repo)
        {
            _repo = repo;
        }
        public List<PhieuMuonSach> dspm = new List<PhieuMuonSach>();
        public List<ChiTietMuonSach> dsct = new List<ChiTietMuonSach>();
        public string LayMa()
        {
            var userManager = HttpContext.RequestServices.GetService<UserManager<ApplicationUser>>();
            var user = userManager.GetUserAsync(User).Result;

            if (user != null)
            {

                if (userManager.IsInRoleAsync(user, "DocGia").Result)
                {
                    return user.MaDocGia;
                }
                else if (userManager.IsInRoleAsync(user, "NhanVien").Result)
                {
                    return user.MaNhanVien;
                }
            }
            return null;

        }
        public void OnGet()
        {
        }
        public async Task OnPostFindDGAsync(string idDocGia)
        {
            dsct.Clear();
            dspm = await _repo.LayPhieuMuon(idDocGia);
        }
        public async Task OnPostFindCT(string idMaPM)
        {
            dspm = await _repo.LayPhieuMuonTheoIdPm(idMaPM);
            dsct = await _repo.LayChiTietPhieuMuon(idMaPM);
        }
        public async Task<IActionResult> OnPostXacNhan(string idMaPM)
        {
            
            string maNhanVien = LayMa(); 

            bool result = await _repo.XacNhanPhieuMuon(idMaPM, maNhanVien);

            if (result)
            {
                TempData["Success"] = "Đã xác nhận phiếu mượn thành công.";
            }
            else
            {
                TempData["Error"] = "Không tìm thấy phiếu mượn hoặc lỗi xử lý.";
            }

            return RedirectToPage(); // reload lại trang
        }
    }
}
