using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLThuVienMVC.Models;
using QLThuVienMVC.ViewModels;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;


namespace QLThuVienMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private InterfaceSach SachRepo;
        public int pageSize = 8;
        public HomeController(ILogger<HomeController> logger, InterfaceSach _sachRepo)
        {
            _logger = logger;
            SachRepo = _sachRepo;
        }
        [HttpGet]
        public IActionResult Index(string? tag, string? name, int page = 1)
        {
            var sachList = SachRepo.LaySach();

            if (!string.IsNullOrEmpty(tag))
                sachList = sachList.Where(c => c.TheLoai == tag);

            if (!string.IsNullOrEmpty(name))
                sachList = sachList.Where(s => s.TenSach.ToLower().Contains(name.ToLower()));


            var totalItems = sachList.Count();

            var sachPage = sachList
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            var vm = new SachViewModel
            {
                Sachs = sachPage,
                Paging = new Paging
                {
                    ItemPerPage = pageSize,
                    TotalItems = totalItems,
                    CurrentPage = page
                },
                currentTag = tag,
                currentName = name
            };

            return View(vm);
        }


        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
