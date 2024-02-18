using ThemSuaXoaDuLieu.Constant;
using ThemSuaXoaDuLieu.Entities;

namespace ThemSuaXoaDuLieu.IServices
{
    public interface IHoaDonServices
    {
        ErrorMessage ThemHoaDon(HoaDon hoaDon);
        public string TaoMaGiaoDich();
        ErrorMessage SuaHoaDon(HoaDon hoaDon);
        ErrorMessage XoaHoaDon(int hoaDonId);
        IEnumerable<HoaDon> GetDsHoaDon();
    }
}
