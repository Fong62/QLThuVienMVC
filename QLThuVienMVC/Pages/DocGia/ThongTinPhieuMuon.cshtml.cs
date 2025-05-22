using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLThuVienMVC.Models;
using QLThuVienMVC.Models.Detail_Lib;
using QLThuVienMVC.Models.UserModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLThuVienMVC.Pages.DocGia
{
    [Authorize(Roles = "DocGia")]
    public class ThongTinPhieuMuonModel : PageModel
    {
        private readonly InterfaceSach _sachRepository;

        [BindProperty]
        public List<PhieuMuonSach> DanhSachPhieuMuon { get; set; }
        public List<ChiTietMuonSach> DanhSachChiTiet { get; set; }
        public string TinhTrangMuon { get; set; }


        public ThongTinPhieuMuonModel(InterfaceSach sachRepository)
        {
            _sachRepository = sachRepository;
        }

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

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var maDocGia = LayMa();
                if (string.IsNullOrEmpty(maDocGia))
                {
                    return Unauthorized();
                }

                DanhSachPhieuMuon = await _sachRepository.LayPhieuMuon(maDocGia);

                if (DanhSachPhieuMuon == null)
                {
                    return NotFound();
                }

                return Page();
            }
            catch (Exception ex)
            {
                // Log the exception
                return RedirectToPage("/Error");
            }
        }
    }
}