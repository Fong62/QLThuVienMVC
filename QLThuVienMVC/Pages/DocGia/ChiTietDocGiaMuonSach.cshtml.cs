using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using QLThuVienMVC.Models.Detail_Lib;
using QLThuVienMVC.Models;

public class ChiTietDocGiaMuonSachModel : PageModel
{
    private readonly InterfaceSach _sachRepository;

    public PhieuMuonSach PhieuMuon { get; set; }
    public List<ChiTietMuonSach> dsct { get; set; }
    public Dictionary<string, string> SachInfo { get; set; } = new Dictionary<string, string>();

    public ChiTietDocGiaMuonSachModel(InterfaceSach sachRepository)
    {
        _sachRepository = sachRepository;
    }

    public async Task<IActionResult> OnGetAsync(string maPM)
    {
        if (string.IsNullOrEmpty(maPM))
        {
            return NotFound();
        }

        PhieuMuon = await _sachRepository.LayPhieuMuonTheoIdPm(maPM)
            .ContinueWith(t => t.Result.FirstOrDefault());

        dsct = await _sachRepository.LayChiTietPhieuMuon(maPM);

        foreach (var item in dsct)
        {
            var sach = await _sachRepository.LaySachTheoId(item.MaSach);
            if (sach != null)
            {
                SachInfo[item.MaSach] = sach.TenSach;
            }
        }

        if (PhieuMuon == null || dsct == null)
        {
            return NotFound();
        }

        return Page();
    }
}
