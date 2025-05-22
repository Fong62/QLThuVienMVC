namespace QLThuVienMVC.Models
{
    public interface InterfaceThongTin
    {
        Task<NhanVien?> LayNhanVienByUserName(string userName);
        Task<DocGia?> LayDocGiaByUserName(string userName);

        Task UpdateNhanVien(NhanVien nhanVien);
        Task UpdateDocGia(DocGia docGia);
    }
}
