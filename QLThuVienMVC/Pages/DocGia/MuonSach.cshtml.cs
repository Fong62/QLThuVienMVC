using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLThuVienMVC.Models;
using QLThuVienMVC.Models.UserModel;
using System.Text.Json;
using System.Threading.Tasks;
using QLThuVienMVC.Infrastructure;

namespace QLThuVienMVC.Pages.DocGia
{
    public class MuonSachModel : PageModel
    {
        private readonly InterfaceSach _repo;
        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl { get; set; }
        public List<Sach> dsSach { get; set; } = new List<Sach>();

        private const string SESSION_KEY = "MuonSachIds";


        public List<string> dsid
        {
            get => HttpContext.Session.GetJson<List<string>>(SESSION_KEY) ?? new List<string>();
            set => HttpContext.Session.SetJson(SESSION_KEY, value);
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
        public MuonSachModel(InterfaceSach repo)
        {
            _repo = repo;
        }

        public async Task OnGet(string id)
        {
            var currentIds = dsid;

            if (!string.IsNullOrEmpty(id))
            {
                if (!currentIds.Contains(id))
                {
                    if (currentIds.Count < 5)
                    {
                        currentIds.Add(id);
                        TempData["SuccessMessage"] = "✅ Đã thêm sách!";
                    }
                    else
                    {
                        TempData["SuccessMessage"] = "⚠️ Tối đa 5 cuốn mỗi lần mượn.";
                    }
                }
                else
                {
                    TempData["SuccessMessage"] = "⚠️ Sách đã có trong danh sách!";
                }
            }

            dsid = currentIds;
            dsSach = await _repo.LayDanhSachTheoIdAsync(currentIds);
        }

        public async Task<IActionResult> OnPostRemove(string id)
        {
            var currentIds = dsid;

            if (!string.IsNullOrEmpty(id) && currentIds.Contains(id))
            {
                currentIds.Remove(id);
                dsid = currentIds;
            }

            dsSach = await _repo.LayDanhSachTheoIdAsync(currentIds);
            return Page();
        }

        public async Task<IActionResult> OnPostAdd()
        {
            var currentIds = dsid;
            string idNgDoc = LayMa();

            if (string.IsNullOrEmpty(idNgDoc) || currentIds.Count == 0)
            {
                TempData["SuccessMessage"] = "⚠️ Không thể mượn sách. Vui lòng kiểm tra lại.";
                return Page();
            }

            await _repo.ThemPhieuMuon(idNgDoc, currentIds);
            TempData["SuccessMessage"] = "✅ Mượn sách thành công!";
            dsid = new List<string>(); // Xóa danh sách sau khi mượn
            dsSach = new List<Sach>(); // Clear danh sách hiển thị

            return Page();
        }
    }
}