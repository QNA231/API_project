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
        public IQueryable<HoaDon> LayHoaDon(string keyword, int? year = null, int? month = null, DateTime? tuNgay = null, DateTime? denNgay = null, int? giaTu = null, int? giaDen = null);
    }
}
