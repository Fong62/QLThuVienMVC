using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QLThuVienMVC.Models.UserModel;

namespace QLThuVienMVC.Models
{
    public class ThongTinRepository : InterfaceThongTin
    {
        private readonly LibDataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public ThongTinRepository(LibDataContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<NhanVien?> LayNhanVienByUserName(string userName)
        {
            return await _context.NhanVien
                .Include(nv => nv.User)
                .FirstOrDefaultAsync(nv => nv.User.UserName == userName);
        }

        public async Task<DocGia?> LayDocGiaByUserName(string userName)
        {
            return await _context.DocGia
                .Include(dg => dg.User)
                .FirstOrDefaultAsync(dg => dg.User.UserName == userName);
        }

        public async Task UpdateNhanVien(NhanVien nhanVien)
        {
            var existing = await _context.NhanVien.FindAsync(nhanVien.MaNhanVien);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(nhanVien);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateDocGia(DocGia docGia)
        {
            var existing = await _context.DocGia
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.MaDocGia == docGia.MaDocGia);

            if (existing != null)
            {
                existing.HoTen = docGia.HoTen;
                existing.NgaySinh = docGia.NgaySinh;
                existing.DiaChi = docGia.DiaChi;
                existing.LoaiDocGia = docGia.LoaiDocGia;

                if (existing.User != null && docGia.User != null)
                {
                    existing.User.Email = docGia.User.Email;
                    existing.User.PhoneNumber = docGia.User.PhoneNumber;

                    await _userManager.UpdateAsync(existing.User);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
