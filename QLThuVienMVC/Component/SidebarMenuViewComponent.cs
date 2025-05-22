using Microsoft.AspNetCore.Mvc;

namespace QLThuVienMVC.Component
{
    public class SidebarMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}