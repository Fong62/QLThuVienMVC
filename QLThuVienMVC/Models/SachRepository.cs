using Microsoft.EntityFrameworkCore;
using QLThuVienMVC.Controllers;
using QLThuVienMVC.Models.Detail_Lib;

namespace QLThuVienMVC.Models
{
    public class SachRepository : InterfaceSach
    {
        private readonly LibDataContext context;

        public SachRepository(LibDataContext _context)
        {
            this.context = _context;
        }

        public IQueryable<Sach> LaySach()
        {
            return context.Sach;
        }
        public async Task<List<Sach>> LayDanhSachTheoIdAsync(List<string> ids)
        {
            return await context.Sach
            .Where(s => ids.Contains(s.MaSach)).ToListAsync();
        }
        public async Task<Sach> LaySachTheoId(string id)
        {
            return await context.Sach.FirstOrDefaultAsync(s => s.MaSach == id);
        }
        public async Task ThemPhieuMuon(string idDocGia, List<string> dsidSach)
        {
            var lastCode = await context.PhieuMuonSach
             .OrderByDescending(pm => pm.MaPhieuMuon)
             .Select(pm => pm.MaPhieuMuon)
             .FirstOrDefaultAsync();

            var maPM = GenerateCode.GenerateNextCode(lastCode, "PM");

            var PhieuMuom = new PhieuMuonSach
            {
                MaPhieuMuon = maPM,
                MaDocGia = idDocGia,
                MaNhanVien = null,
                NgayMuon = DateTime.Now,
            };
            context.PhieuMuonSach.Add(PhieuMuom);
            foreach (var masach in dsidSach)
            {
                var ChiTietPm = new ChiTietMuonSach
                {
                    MaPhieuMuon = maPM,
                    MaSach = masach,
                    NgayPhaiTra = null,
                    TinhTrangMuon = "Đang chờ duyệt"
                };
                context.ChiTietMuonSach.Add(ChiTietPm);
            }
            await context.SaveChangesAsync();
        }
        public async Task<List<PhieuMuonSach>> LayPhieuMuon(string maDocGia)
        {
            return await context.PhieuMuonSach
                       .Where(p => p.MaDocGia == maDocGia)
                       .ToListAsync();
        }
        public async Task<List<PhieuMuonSach>> LayPhieuMuonTheoIdPm(string maPM)
        {
            return await context.PhieuMuonSach
                       .Where(p => p.MaPhieuMuon == maPM)
                       .ToListAsync();
        }
        public async Task<List<ChiTietMuonSach>> LayChiTietPhieuMuon(string maPM)
        {
            return await context.ChiTietMuonSach
                .Where(p => p.MaPhieuMuon == maPM) //&& p.TinhTrangMuon == "Đang chờ duyệt")
                       .ToListAsync(); ;
        }
        public async Task<bool> XacNhanPhieuMuon(string maPhieuMuon, string maNhanVien)
        {

            var phieu = await context.PhieuMuonSach
                .FirstOrDefaultAsync(p => p.MaPhieuMuon == maPhieuMuon);

            if (phieu == null)
                return false;

            var dsMaSach = await context.ChiTietMuonSach
                .Where(ct => ct.MaPhieuMuon == maPhieuMuon)
                .Select(ct => ct.MaSach)
                .ToListAsync();

            phieu.MaNhanVien = maNhanVien;


            var chiTietList = await context.ChiTietMuonSach
                .Where(ct => ct.MaPhieuMuon == maPhieuMuon && ct.TinhTrangMuon == "Đang chờ duyệt")
                .ToListAsync();

            foreach (var ct in chiTietList)
            {
                ct.TinhTrangMuon = "Đã duyệt";
                ct.NgayPhaiTra = DateTime.Now.AddDays(7);
            }
            foreach (var id in dsMaSach)
            {
                var sach = await context.Sach.FirstOrDefaultAsync(s => s.MaSach == id);
                if (sach == null) continue;

                sach.TinhTrang = "Không có sẵn";
            }
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<List<ChiTietMuonSach>> LayPCThieuMuonDaDuyet(string idMaDocGia)
        {
            var PhieuMuonId = await context.PhieuMuonSach
                .Where(pm => pm.MaDocGia == idMaDocGia && pm.MaNhanVien != null)
                .Select(pm => pm.MaPhieuMuon).ToListAsync();
            if (PhieuMuonId == null || !PhieuMuonId.Any())
                return new List<ChiTietMuonSach>();

            var dsct = await context.ChiTietMuonSach
                .Where(ct => PhieuMuonId.Contains(ct.MaPhieuMuon) && ct.TinhTrangMuon == "Đã duyệt")
                .ToListAsync();

            return dsct;
        }
        public async Task<bool> ThemPhieuTra(string idDocGia, List<string> dsid, List<string> dstt, string maNhanVien)
        {
            if (dsid == null || !dsid.Any()) return false;

            
            var lastCode = await context.PhieuTraSach
                .OrderByDescending(pt => pt.MaPhieuTra)
                .Select(pt => pt.MaPhieuTra)
                .FirstOrDefaultAsync();

            var maPT = GenerateCode.GenerateNextCode(lastCode, "PT");

            // Create new return slip
            var phieuTra = new PhieuTraSach
            {
                MaPhieuTra = maPT,
                MaDocGia = idDocGia,
                MaNhanVien = maNhanVien,
                NgayTra = DateTime.Now,
                TienPhat = 0
            };

            context.PhieuTraSach.Add(phieuTra);
            await context.SaveChangesAsync(); 

            decimal tongTienPhat = 0;
            var processedBooks = new HashSet<string>(); 

            for (int i = 0; i < dsid.Count; i++)
            {
                var maSach = dsid[i];

               
                if (processedBooks.Contains(maSach))
                    continue;

                processedBooks.Add(maSach);

                var ctMuon = await context.ChiTietMuonSach
                    .FirstOrDefaultAsync(ct => ct.MaSach == maSach && ct.TinhTrangMuon == "Đã duyệt");

                if (ctMuon == null) continue;

                var ngayPhaiTra = ctMuon.NgayPhaiTra ?? DateTime.Now;
                var ngayTraThucTe = DateTime.Now;
                var soNgayTre = (ngayTraThucTe - ngayPhaiTra).Days;

                int tre = soNgayTre > 0 ? soNgayTre : 0;
                decimal tienPhat = tre * 1000;

                tongTienPhat += tienPhat;

                var ctTra = new ChiTietTraSach
                {
                    MaPhieuTra = maPT,
                    MaSach = maSach,
                    NgayTraThucTe = ngayTraThucTe,
                    SoNgayTre = tre,
                    TinhTrangTra = tre > 0 ? "Trả trễ" : "Đúng hạn"
                };

                context.ChiTietTraSach.Add(ctTra);

                var sach = await context.Sach.FirstOrDefaultAsync(s => s.MaSach == maSach);
                if (sach != null)
                {
                    if (dstt[i] == "Còn mới")
                    {
                        sach.TinhTrang = "Có sẵn";
                    }
                    else
                    {
                        sach.TinhTrang = "Không có sẵn";
                        tongTienPhat += (int)sach.GiaTri;
                    }
                }
                else
                {
                    return false;
                }

                ctMuon.TinhTrangMuon = "Đã trả";
            }

            phieuTra.TienPhat = tongTienPhat;
            await context.SaveChangesAsync();
            return true;
        }
       
    }
}

