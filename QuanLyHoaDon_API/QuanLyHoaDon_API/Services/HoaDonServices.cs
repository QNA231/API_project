using QuanLyHoaDon_API.Constant;
using QuanLyHoaDon_API.Entities;
using QuanLyHoaDon_API.IServices;

namespace QuanLyHoaDon_API.Services
{
    public class HoaDonServices : IHoaDonServices
    {
        public readonly AppDbContext dbContext;

        public HoaDonServices()
        {
            dbContext = new AppDbContext();
        }

        public string TaoMaGiaoDich()
        {
            string str = DateTime.Now.ToString("yyyyMMdd") + "_";
            var countSoGDHomNay = dbContext.HoaDon.Count(x => x.ThoiGianTao.Date == DateTime.Now.Date);
            if(countSoGDHomNay > 0)
            {
                int tmp = countSoGDHomNay + 1;
                if(tmp < 10)
                {
                    return str += "00" + tmp.ToString();
                }else if(tmp < 100)
                {
                    return str += "0" + tmp.ToString();
                }
                else
                {
                    return str + tmp.ToString();
                }
            }
            return str + "001";
        }

        public HoaDon ThemHoaDon(HoaDon hoaDon)
        {
            hoaDon.ThoiGianTao = DateTime.Now;
            hoaDon.MaGiaoDich = TaoMaGiaoDich();

            var lstCTHD = hoaDon.ChiTietHoaDons;
            hoaDon.ChiTietHoaDons = null;

            dbContext.Add(hoaDon);
            dbContext.SaveChanges();

            foreach(var chiTiet in lstCTHD)
            {
                if(dbContext.SanPham.Any(x => x.SanPhamId == chiTiet.SanPhamId))
                {
                    chiTiet.HoaDonId = hoaDon.HoaDonId;
                    var sp = dbContext.SanPham.FirstOrDefault(x => x.SanPhamId == chiTiet.SanPhamId);
                    chiTiet.ThanhTien = sp.GiaThanh * chiTiet.SoLuong;
                    dbContext.Add(chiTiet);
                    dbContext.SaveChanges();
                }
                else
                {
                    return ErrorMessage.SanPhamKhongTonTai;
                }
            }
            hoaDon.TongTien += lstCTHD.Sum(x => x.ThanhTien);
            dbContext.SaveChanges();
            return 
        }
    }
}
