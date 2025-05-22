using QLThuVienMVC.Models;
using Microsoft.AspNetCore.Mvc;
using QLThuVienMVC.ViewModels;


namespace QLThuVienMVC.Component
{
    public class TheLoaiViewComponent : ViewComponent
    {
        public InterfaceSach sach;

        public TheLoaiViewComponent(InterfaceSach _sachRepo)
        {
            sach = _sachRepo;
        }
       
        public IViewComponentResult Invoke()
        {
            ViewBag.currentTag = HttpContext.Request?.Query["tag"].ToString();
            ViewBag.TotalCount = sach.LaySach().Count();
            ViewBag.TheLoaiCounts = sach.LaySach()
            .GroupBy(b => b.TheLoai)
            .ToDictionary(g => g.Key, g => g.Count());
            var theloai = sach.LaySach().Select(s => s.TheLoai).Distinct().OrderBy(s => s);
            return View(theloai);

        }
    }
}
