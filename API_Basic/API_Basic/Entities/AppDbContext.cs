using Microsoft.EntityFrameworkCore;

namespace API_Basic.Entities
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<HocSinh> HocSinh { get; set; }
        public virtual DbSet<Lop> Lop { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server = LAPTOP-1600EKM7\\SQLEXPRESS; Database = QLHocSinh; Trusted_Connection = True; TrustServerCertificate = True");
        }
    }
}
