using Microsoft.EntityFrameworkCore;

namespace ThemSuaXoaDuLieu.Entities
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server = LAPTOP-1600EKM7\\SQLEXPRESS; Database = QLSanPhamHoaDonAPI; Trusted_Connection = True; TrustServerCertificate = True");
        }
    }
}
