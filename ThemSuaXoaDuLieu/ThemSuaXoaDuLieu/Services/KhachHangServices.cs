using ThemSuaXoaDuLieu.Constant;
using ThemSuaXoaDuLieu.Entities;
using ThemSuaXoaDuLieu.IServices;

namespace ThemSuaXoaDuLieu.Services
{
    public class KhachHangServices : IKhachHangServices
    {
        private readonly AppDbContext dbContext;

        public KhachHangServices()
        {
            dbContext = new AppDbContext();
        }

        public ErrorMessage ThemKhachHang(KhachHang khachHang)
        {
            khachHang = new KhachHang();
            return ErrorMessage.ThanhCong;
        }
    }
}
