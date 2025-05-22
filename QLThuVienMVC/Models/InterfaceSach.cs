using QLThuVienMVC.Models.Detail_Lib;
namespace QLThuVienMVC.Models
{
    public interface InterfaceSach
    {
        public IQueryable<Sach> LaySach();
        public Task<List<Sach>> LayDanhSachTheoIdAsync(List<string> id);
        public Task<Sach> LaySachTheoId(string id);
        public Task ThemPhieuMuon(string idDocGia, List<string> dsid);
        public Task<bool> ThemPhieuTra(string idDocGia, List<string> dsid, List<string> dstt, string maNhanVien);
        public Task<List<PhieuMuonSach>> LayPhieuMuon(string maDocGia);
        public Task<List<PhieuMuonSach>> LayPhieuMuonTheoIdPm(string maPM);
        public Task<List<ChiTietMuonSach>> LayChiTietPhieuMuon(string maPm);
        public Task<bool> XacNhanPhieuMuon(string maPhieuMuon, string maNhanVien);
        public Task<List<ChiTietMuonSach>> LayPCThieuMuonDaDuyet(string maDocGia);
    }
}