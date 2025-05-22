using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLThuVienMVC.Models.Detail_Lib;
using System;
using System.Linq;

namespace QLThuVienMVC.Models
{
    public static class SeedData
    {
        public static void SeedDatabase(LibDataContext context)
        {
            //context.Database.Migrate();
            
            if (!context.Sach.Any())
            {
                context.NhaCungCap.AddRange(
                    new NhaCungCap
                    {
                        MaNhaCungCap= "NCC001",
                        TenNhaCungCap= "Công ty Sách Tri Thức",
                        DiaChi= "123 Đường Văn Lang, Hà Nội",
                        SoDienThoai = 024 - 37651234,
                        Email= "lienhe@trithucbooks.vn"
                    }
                );

                context.Sach.AddRange(
                    new Sach
                    {
                        MaSach = "B001",
                        TenSach = "Lập Trình C# Cơ Bản",
                        TacGia = "Nguyễn Văn A",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 5, 1),
                        GiaTri = 189000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b001.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B002",
                        TenSach = "Học Python Trong 21 Ngày",
                        TacGia = "Trần Thị B",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 5, 2),
                        GiaTri = 225000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b002.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B003",
                        TenSach = "Giải Thuật và Cấu Trúc Dữ Liệu",
                        TacGia = "Lê Văn C",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,  
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 5, 3),
                        GiaTri = 275000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b003.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B004",
                        TenSach = "Thiết Kế Web Với HTML/CSS",
                        TacGia = "Phạm Thị D",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 5, 4),
                        GiaTri = 199000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b004.jpg",
                        MaNhaCungCap = "NCC001"
                    },

                    new Sach
                    {
                        MaSach = "B005",
                        TenSach = "Cơ Sở Dữ Liệu SQL Server",
                        TacGia = "Hoàng Văn E",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 5, 5),
                        GiaTri = 245000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b005.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B006",
                        TenSach = "Machine Learning Cơ Bản",
                        TacGia = "Vũ Thị F",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 5, 6),
                        GiaTri = 315000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b006.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B007",
                        TenSach = "Deep Learning Nâng Cao",
                        TacGia = "Đỗ Văn G",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 5, 7),
                        GiaTri = 355000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b007.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B008",
                        TenSach = "Nhập Môn ReactJS",
                        TacGia = "Lương Thị H",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 5, 8),
                        GiaTri = 219000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b008.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B009",
                        TenSach = "Vue.js Toàn Tập",
                        TacGia = "Bùi Văn I",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 5, 9),
                        GiaTri = 239000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b009.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B010",
                        TenSach = "Flutter Cho Mobile",
                        TacGia = "Hoàng Thị K",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 5, 10),
                        GiaTri = 289000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b010.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B011",
                        TenSach = "React Native Thực Chiến",
                        TacGia = "Ngô Văn L",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 5, 11),
                        GiaTri = 265000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b011.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B012",
                        TenSach = "Node.js & Express",
                        TacGia = "Phan Thị M",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 5, 12),
                        GiaTri = 229000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b012.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B013",
                        TenSach = "Docker Cho DevOps",
                        TacGia = "Trần Văn N",
                        TheLoai = "DevOps",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 5, 13),
                        GiaTri = 299000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b013.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B014",
                        TenSach = "Kubernetes Toàn Tập",
                        TacGia = "Đặng Thị O",
                        TheLoai = "DevOps",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 5, 14),
                        GiaTri = 345000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b014.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B015",
                        TenSach = "Thiết Kế API với ASP.NET Core",
                        TacGia = "Lê Thị P",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 5, 15),
                        GiaTri = 275000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b015.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B016",
                        TenSach = "Ứng Dụng Microservices",
                        TacGia = "Nguyễn Văn Q",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 5, 16),
                        GiaTri = 325000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b016.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B017",
                        TenSach = "Bảo Mật Ứng Dụng Web",
                        TacGia = "Phạm Văn R",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 5, 17),
                        GiaTri = 249000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b017.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B018",
                        TenSach = "Phát Triển Game Unity",
                        TacGia = "Hoàng Văn S",
                        TheLoai = "Game Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 5, 18),
                        GiaTri = 295000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b018.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B019",
                        TenSach = "Phát Triển Game Unreal",
                        TacGia = "Vũ Thị T",
                        TheLoai = "Game Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 5, 19),
                        GiaTri = 335000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b019.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B020",
                        TenSach = "Công Nghệ Blockchain",
                        TacGia = "Đỗ Văn U",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 5, 20),
                        GiaTri = 285000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b020.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B021",
                        TenSach = "Ứng dụng bảo mật Microservices",
                        TacGia = "Nguyễn Tấn V",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 5, 21),
                        GiaTri = 315000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b021.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B022",
                        TenSach = "Ứng dụng công nghệ GitHub",
                        TacGia = "Trần Hữu X",
                        TheLoai = "DevOps",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 5, 22),
                        GiaTri = 255000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b022.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B023",
                        TenSach = "Nền tảng cho lập trình viên Java",
                        TacGia = "Nguyễn Phúc Y",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 5, 23),
                        GiaTri = 235000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b023.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B024",
                        TenSach = "CSS chuyên sâu",
                        TacGia = "Lê Quang Z",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 5, 24),
                        GiaTri = 205000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b024.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B025",
                        TenSach = "Học C++ qua ví dụ",
                        TacGia = "Trần Ngọc A",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 5, 25),
                        GiaTri = 225000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b025.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B026",
                        TenSach = "Kiểm thử phần mềm hiệu quả",
                        TacGia = "Hoàng Anh B",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 5, 26),
                        GiaTri = 265000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b026.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B027",
                        TenSach = "Nền tảng cho lập trình viên Python",
                        TacGia = "Trịnh Hoài C",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 5, 27),
                        GiaTri = 245000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b027.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B028",
                        TenSach = "C# chuyên sâu",
                        TacGia = "Phan Đức D",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 5, 28),
                        GiaTri = 235000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b028.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B029",
                        TenSach = "Core Kubernetes",
                        TacGia = "Nguyễn Thiên E",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 5, 29),
                        GiaTri = 325000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b029.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B030",
                        TenSach = "100 lỗi C++ và cách sửa đổi",
                        TacGia = "Phạm Minh F",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 5, 30),
                        GiaTri = 195000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b030.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B031",
                        TenSach = "Chuyên sâu HTML5 với CSS, JavaScript & Multimedia",
                        TacGia = "Lê Trung G",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 5, 31),
                        GiaTri = 285000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b031.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B032",
                        TenSach = "Nhập môn JQuery",
                        TacGia = "Trịnh Đình H",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 6, 1),
                        GiaTri = 215000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b032.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B033",
                        TenSach = "Cấu trúc dữ liệu & giải thuật JavaScript",
                        TacGia = "Đỗ Tấn I",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 6, 2),
                        GiaTri = 245000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b033.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B034",
                        TenSach = "Quản lý nội dung Web",
                        TacGia = "Nguyễn Công J",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 6, 3),
                        GiaTri = 225000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b034.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B035",
                        TenSach = "Xây dựng Tools với GitHub",
                        TacGia = "Phạm Đức K",
                        TheLoai = "DevOps",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 6, 4),
                        GiaTri = 295000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b035.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B036",
                        TenSach = "Lập trình PHP chuyên nghiệp",
                        TacGia = "Lê Thành L",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 6, 5),
                        GiaTri = 235000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b036.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B037",
                        TenSach = "Công thức Java hiện đại",
                        TacGia = "Nguyễn Quang M",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 6, 6),
                        GiaTri = 255000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b037.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B038",
                        TenSach = "Nhập Môn Docker",
                        TacGia = "Nguyễn Quang N",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 6, 7),
                        GiaTri = 215000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b038.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B039",
                        TenSach = "Node.js cho lập trình viên .Net",
                        TacGia = "Trần Đình N",
                        TheLoai = "DevOps",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 6, 8),
                        GiaTri = 275000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b039.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B040",
                        TenSach = "Xây dựng ứng dụng web với Visual Studio",
                        TacGia = "Lê Nhật O",
                        TheLoai = "DevOps",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 6, 9),
                        GiaTri = 295000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b040.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B041",
                        TenSach = "Trí tuệ nhân tạo cho .NET",
                        TacGia = "Trần Quốc P",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 6, 10),
                        GiaTri = 335000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b041.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B042",
                        TenSach = "Phát triển game Unity với C#",
                        TacGia = "Nguyễn Tấn Q",
                        TheLoai = "Game Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 6, 11),
                        GiaTri = 285000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b042.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B043",
                        TenSach = "Phát triển game mobile trên Unity 2022",
                        TacGia = "Lê Nam R",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 6, 12),
                        GiaTri = 305000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b043.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B044",
                        TenSach = "Thuật toán phát triển game với Unity 3D",
                        TacGia = "Phan Thành S",
                        TheLoai = "Game Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 6, 13),
                        GiaTri = 315000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b044.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B045",
                        TenSach = "Động cơ trí tuệ nhân tạo",
                        TacGia = "Trần Ngọc T",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 6, 14),
                        GiaTri = 345000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b045.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B046",
                        TenSach = "Data Science cơ bản",
                        TacGia = "Phạm Anh U",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 6, 15),
                        GiaTri = 295000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b046.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B047",
                        TenSach = "Machine Learning thực hành",
                        TacGia = "Nguyễn Nhật V",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 6, 16),
                        GiaTri = 325000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b047.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B048",
                        TenSach = "Máy dự đoán",
                        TacGia = "Phạm Văn W",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 6, 17),
                        GiaTri = 355000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b048.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B049",
                        TenSach = "Deep Learning",
                        TacGia = "Phan Quốc X",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 6, 18),
                        GiaTri = 375000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b049.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B050",
                        TenSach = "Minh họa Deep Learning",
                        TacGia = "Trần Văn Y",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 6, 19),
                        GiaTri = 285000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b050.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B051",
                        TenSach = "Lập trình Mobile",
                        TacGia = "Lê Văn Z",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 6, 20),
                        GiaTri = 245000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b051.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B052",
                        TenSach = "AI & Machine Learning cho lập trình viên",
                        TacGia = "Lê Quốc A",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 6, 21),
                        GiaTri = 315000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b052.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B053",
                        TenSach = "Lập trình Android",
                        TacGia = "Đỗ Thanh B",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 6, 22),
                        GiaTri = 265000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b053.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B054",
                        TenSach = "Con đường đến React",
                        TacGia = "Nguyễn Mạnh C",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 6, 23),
                        GiaTri = 235000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b054.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B055",
                        TenSach = "Xây dựng Web App hiện đại",
                        TacGia = "Nguyễn Thành D",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 6, 24),
                        GiaTri = 275000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b055.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B056",
                        TenSach = "Phát triển ứng dụng di động",
                        TacGia = "Lê Hải E",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 6, 25),
                        GiaTri = 295000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b056.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B057",
                        TenSach = "Tối ưu hóa AppStore",
                        TacGia = "Lê Bảo F",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 6, 26),
                        GiaTri = 225000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b057.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B058",
                        TenSach = "Bẻ khóa Iphone và phát triển Android",
                        TacGia = "Trần Quốc G",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 6, 27),
                        GiaTri = 315000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b058.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B059",
                        TenSach = "Phát triển ứng dụng di động tinh gọn",
                        TacGia = "Nguyễn Trần Gia H",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 6, 28),
                        GiaTri = 285000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b059.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B060",
                        TenSach = "Phát triển ứng dụng di động toàn diện",
                        TacGia = "Lê Đức I",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 6, 29),
                        GiaTri = 305000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b060.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B061",
                        TenSach = "Phát triển an toàn cho ứng dụng di động",
                        TacGia = "Lê Văn J",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 6, 30),
                        GiaTri = 275000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b061.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B062",
                        TenSach = "Ứng dụng tiếp thị & Ứng dụng bán hàng",
                        TacGia = "Lê Văn K",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 7, 1),
                        GiaTri = 255000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b062.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B063",
                        TenSach = "Nghệ thuật thiết kế trò chơi",
                        TacGia = "Nguyễn Minh L",
                        TheLoai = "Game Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 7, 2),
                        GiaTri = 325000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b063.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B064",
                        TenSach = "Games, Thiết kế & Chơi",
                        TacGia = "Phan Ngọc M",
                        TheLoai = "Game Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 7, 3),
                        GiaTri = 295000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b064.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B065",
                        TenSach = "Các mẫu lập trình trò chơi",
                        TacGia = "Nguyễn Quốc N",
                        TheLoai = "Game Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 7, 4),
                        GiaTri = 315000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b065.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B066",
                        TenSach = "Lập trình Game AI qua ví dụ",
                        TacGia = "Trịnh Hùng O",
                        TheLoai = "Game Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 7, 5),
                        GiaTri = 335000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b066.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B067",
                        TenSach = "Cấu trúc dữ liệu & giải thuật trong C++",
                        TacGia = "Lê Bảo P",
                        TheLoai = "CNTT",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 7, 6),
                        GiaTri = 275000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b067.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B068",
                        TenSach = "Phát hiện va chạm thời gian thực",
                        TacGia = "Phạm Hữu Q",
                        TheLoai = "Game Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 7, 7),
                        GiaTri = 305000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b068.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B069",
                        TenSach = "Sổ tay DevOps",
                        TacGia = "Phạm Hồng R",
                        TheLoai = "DevOps",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 7, 8),
                        GiaTri = 245000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b069.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B070",
                        TenSach = "Kỹ thuật với độ tin cậy của web",
                        TacGia = "Trịnh Quốc S",
                        TheLoai = "DevOps",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 7, 9),
                        GiaTri = 265000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b070.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B071",
                        TenSach = "DevOps hiệu quả",
                        TacGia = "Lê Minh T",
                        TheLoai = "DevOps",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 7, 10),
                        GiaTri = 285000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b071.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B072",
                        TenSach = "Sổ tay về độ tin cậy của web",
                        TacGia = "Lê Quang U",
                        TheLoai = "DevOps",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 7, 11),
                        GiaTri = 295000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b072.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B073",
                        TenSach = "Ansible cho DevOps",
                        TacGia = "Lê Hữu V",
                        TheLoai = "DevOps",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 7, 12),
                        GiaTri = 315000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b073.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B074",
                        TenSach = "Xử lý sự cố DevOps",
                        TacGia = "Nguyễn Hồng W",
                        TheLoai = "DevOps",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 7, 13),
                        GiaTri = 275000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b074.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B075",
                        TenSach = "DevOps nguyên bản đám mây với Kubernetes",
                        TacGia = "Nguyễn Anh X",
                        TheLoai = "DevOps",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 7, 14),
                        GiaTri = 345000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b075.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B076",
                        TenSach = "Trí tuệ nhân tạo: Bước chạm đến hiện đại",
                        TacGia = "Phạm Nhật Y",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 7, 15),
                        GiaTri = 365000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b076.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B077",
                        TenSach = "Khát vọng học máy",
                        TacGia = "Trần Quốc Z",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 7, 16),
                        GiaTri = 285000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b077.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B078",
                        TenSach = "Giới thiệu học tăng cường",
                        TacGia = "Trần Quốc A",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 7, 17),
                        GiaTri = 305000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b078.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B079",
                        TenSach = "Kỹ thuật AI",
                        TacGia = "Phạm Nhật B",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 7, 18),
                        GiaTri = 325000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b079.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B080",
                        TenSach = "Khoa học dữ liệu cho doanh nghiệp",
                        TacGia = "Nguyễn Anh C",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 7, 19),
                        GiaTri = 295000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b080.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B081",
                        TenSach = "Bài toán căn chỉnh: Học máy và bài toán nhân loại",
                        TacGia = "Nguyễn Hồng D",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 7, 20),
                        GiaTri = 335000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b081.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B082",
                        TenSach = "Lịch sử của trí tuệ nhân tạo",
                        TacGia = "Lê Hữu E",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 7, 21),
                        GiaTri = 275000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b082.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B083",
                        TenSach = "Cuộc sống 3.0: Con người trong kỷ nguyên AI",
                        TacGia = "Lê Quang F",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 7, 22),
                        GiaTri = 315000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b083.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B084",
                        TenSach = "Cơ sở của học máy cho phân tích dữ liệu dự đoán",
                        TacGia = "Lê Minh G",
                        TheLoai = "AI/ML",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 7, 23),
                        GiaTri = 345000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b084.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B085",
                        TenSach = "JavaScript và Query",
                        TacGia = "Trịnh Quốc H",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 7, 24),
                        GiaTri = 225000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b085.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B086",
                        TenSach = "JavaScript hùng biện",
                        TacGia = "Phạm Hồng I",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 7, 25),
                        GiaTri = 235000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b086.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B087",
                        TenSach = "Học PHP, MySQL & JavaScript",
                        TacGia = "Phạm Hữu J",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 7, 26),
                        GiaTri = 255000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b087.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B088",
                        TenSach = "PHP cho web",
                        TacGia = "Lê Bảo K",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 7, 27),
                        GiaTri = 245000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b088.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B089",
                        TenSach = "Học JavaScript cấp tốc",
                        TacGia = "Trịnh Hùng L",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 7, 28),
                        GiaTri = 215000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b089.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B090",
                        TenSach = "Bí mật Css",
                        TacGia = "Nguyễn Quốc M",
                        TheLoai = "Web Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 7, 29),
                        GiaTri = 225000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b090.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B091",
                        TenSach = "Bàn luận thiết kế trò chơi",
                        TacGia = "Phan Ngọc N",
                        TheLoai = "Game Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 7, 30),
                        GiaTri = 295000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b091.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B092",
                        TenSach = "Sách hướng dẫn phát triển Unity",
                        TacGia = "Nguyễn Minh O",
                        TheLoai = "Game Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 7, 31),
                        GiaTri = 315000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b092.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B093",
                        TenSach = "Unity từ số 0 đến chuyên nghiệp",
                        TacGia = "Lê Văn P",
                        TheLoai = "Game Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 8, 1),
                        GiaTri = 325000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b093.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B094",
                        TenSach = "Lên cấp! Những hướng dẫn thiết kế video game",
                        TacGia = "Lê Đức Q",
                        TheLoai = "Game Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 8, 2),
                        GiaTri = 305000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b094.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B095",
                        TenSach = "Cảm nhận trò chơi: Hướng dẫn về cảm giác ảo",
                        TacGia = "Đỗ Thanh R",
                        TheLoai = "Game Dev",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 8, 3),
                        GiaTri = 285000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b095.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B096",
                        TenSach = "Phát triển ứng dụng di động",
                        TacGia = "Nguyễn Mạnh S",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 8, 4),
                        GiaTri = 265000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b096.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B097",
                        TenSach = "Học Java để phát triển Android",
                        TacGia = "Nguyễn Thành T",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Trẻ",
                        NgayNhap = new DateTime(2025, 8, 5),
                        GiaTri = 245000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b097.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B098",
                        TenSach = "Phát triển ứng dụng di động",
                        TacGia = "Lê Quốc V",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Giáo Dục",
                        NgayNhap = new DateTime(2025, 8, 6),
                        GiaTri = 275000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b098.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B099",
                        TenSach = "Phát triển giao diện di động với Ionic và React",
                        TacGia = "Phan Võ Anh U",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Khoa Học",
                        NgayNhap = new DateTime(2025, 8, 7),
                        GiaTri = 295000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b099.jpg",
                        MaNhaCungCap = "NCC001"
                    },
                    new Sach
                    {
                        MaSach = "B100",
                        TenSach = "Lập trình IOS",
                        TacGia = "Quách Tuấn V",
                        TheLoai = "Di Động",
                        NamXuatBan = DateTime.Now,
                        NhaXuatBan = "NXB Tổng Hợp",
                        NgayNhap = new DateTime(2025, 8, 8),
                        GiaTri = 315000,
                        TinhTrang = "Mới",
                        coverUrl = "covers/b100.jpg",
                        MaNhaCungCap = "NCC001"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
