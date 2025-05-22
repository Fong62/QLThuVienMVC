using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using QLThuVienMVC.Models;

namespace QLThuVienMVC.Component
{
    public class TimKiemSachViewComponent : ViewComponent
    {
        public InterfaceSach InterfaceSach;
        public TimKiemSachViewComponent(InterfaceSach interfaceSach)
        {
            InterfaceSach = interfaceSach;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.currentName = HttpContext.Request?.Query["name"].ToString();
            return View();
        }
    }
}
