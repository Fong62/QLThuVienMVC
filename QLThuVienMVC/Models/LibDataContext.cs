using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLThuVienMVC.Models.Detail_Lib;
using QLThuVienMVC.Models.UserModel;

namespace QLThuVienMVC.Models
{
    public class LibDataContext : IdentityDbContext<ApplicationUser>
    {
           public LibDataContext(DbContextOptions<LibDataContext> options)
                : base(options)
            {
            }

            public DbSet<NhanVien> NhanVien { get; set; }
            public DbSet<DocGia> DocGia { get; set; }
            public DbSet<NhaCungCap> NhaCungCap { get; set; }
            public DbSet<Sach> Sach { get; set; }
            public DbSet<PhieuCungCap> PhieuCungCap { get; set; }
            public DbSet<ChiTietCungCap> ChiTietCungCap { get; set; }
            public DbSet<PhieuMuonSach> PhieuMuonSach { get; set; }
            public DbSet<ChiTietMuonSach> ChiTietMuonSach { get; set; }
            public DbSet<PhieuTraSach> PhieuTraSach { get; set; }
            public DbSet<ChiTietTraSach> ChiTietTraSach { get; set; }
            public DbSet<PhieuThu> PhieuThu { get; set; }
            public DbSet<ThanhLySach> ThanhLySach { get; set; }
            public DbSet<BaoCao> BaoCao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ChiTietTraSach>()
                 .HasKey(c => new { c.MaPhieuTra, c.MaSach });

            modelBuilder.Entity<ChiTietTraSach>()
                .HasOne(c => c.Sach)
                .WithMany(s => s.ChiTietTraSach)
                .HasForeignKey(c => c.MaSach);

            modelBuilder.Entity<ChiTietTraSach>()
                .HasOne(c => c.PhieuTraSach)
                .WithMany(p => p.ChiTietTraSach)
                .HasForeignKey(c => c.MaPhieuTra);

            modelBuilder.Entity<ChiTietMuonSach>()
               .HasKey(c => new { c.MaPhieuMuon, c.MaSach });

            modelBuilder.Entity<ChiTietMuonSach>()
                .HasOne(c => c.Sach)
                .WithMany(s => s.ChiTietMuonSach)
                .HasForeignKey(c => c.MaSach);

            modelBuilder.Entity<ChiTietMuonSach>()
                .HasOne(c => c.PhieuMuonSach)
                .WithMany(p => p.ChiTietMuonSach)
                .HasForeignKey(c => c.MaPhieuMuon);

            modelBuilder.Entity<ChiTietCungCap>()
                .HasKey(c => new { c.MaPhieuCungCap, c.MaSach });

            modelBuilder.Entity<ChiTietCungCap>()
                .HasOne(c => c.Sach)
                .WithMany(s => s.ChiTietCungCap)
                .HasForeignKey(c => c.MaSach);

            modelBuilder.Entity<ChiTietCungCap>()
                .HasOne(c => c.PhieuCungCap)
                .WithMany(p => p.ChiTietCungCap)
                .HasForeignKey(c => c.MaPhieuCungCap);


            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.NhanVien)
                .WithOne(nv => nv.User)
                .HasForeignKey<ApplicationUser>(u => u.MaNhanVien);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.DocGia)
                .WithOne(dg => dg.User)
                .HasForeignKey<ApplicationUser>(u => u.MaDocGia);

            modelBuilder.Entity<Sach>()
                 .HasOne(s => s.ThanhLySach)
                 .WithOne(t => t.Sach)
                 .HasForeignKey<ThanhLySach>(t => t.MaSach);

            modelBuilder.Entity<Sach>()
                .HasOne(s => s.NhaCungCap)
                .WithMany(n => n.Sach)
                .HasForeignKey(s => s.MaNhaCungCap);


            modelBuilder.Entity<ChiTietCungCap>()
                .Property(ct => ct.Gia)
                .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<PhieuCungCap>()
                .Property(p => p.TongGiaTri)
                .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<PhieuThu>()
                .Property(p => p.TienNo)
                .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<PhieuThu>()
                .Property(p => p.SoTienThu)
                .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<PhieuTraSach>()
                .Property(p => p.TienPhat)
                .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<Sach>()
                .Property(s => s.GiaTri)
                .HasColumnType("decimal(15,2)");
        }
    }
 }



