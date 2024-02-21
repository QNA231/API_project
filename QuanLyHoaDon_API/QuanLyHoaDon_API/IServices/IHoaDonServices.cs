using QuanLyHoaDon_API.Entities;

namespace QuanLyHoaDon_API.IServices
{
    public interface IHoaDonServices
    {
        HoaDon ThemHoaDon(HoaDon hoaDon);
        string TaoMaGiaoDich();
    }
}
