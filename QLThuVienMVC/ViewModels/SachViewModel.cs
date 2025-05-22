using QLThuVienMVC.Models;
namespace QLThuVienMVC.ViewModels
{
    public class SachViewModel
    {
        public Paging Paging { get; set; } = new Paging();
        public IEnumerable<Sach> Sachs { get; set; } = Enumerable.Empty<Sach>();
        public string? currentTag { get; set; }
        public string? currentName { get; set; }
    }
}
