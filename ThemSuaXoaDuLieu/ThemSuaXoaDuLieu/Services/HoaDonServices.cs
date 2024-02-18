using ThemSuaXoaDuLieu.Constant;
using ThemSuaXoaDuLieu.Entities;
using ThemSuaXoaDuLieu.IServices;

namespace ThemSuaXoaDuLieu.Services
{
    public class HoaDonServices : IHoaDonServices
    {
        private readonly AppDbContext dbContext;

        public HoaDonServices()
        {
            dbContext = new AppDbContext();
        }

        public IEnumerable<HoaDon> GetDsHoaDon()
        {
            return dbContext.HoaDon.AsQueryable();
        }

        public ErrorMessage SuaHoaDon(HoaDon hoaDon)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                if(hoaDon.ChiTietHoaDons == null || hoaDon.ChiTietHoaDons.Count() == 0)
                {
                    var lstCTHDHTai = dbContext.ChiTietHoaDon.Where(x => x.HoaDonId == hoaDon.HoaDonId);
                    dbContext.RemoveRange(lstCTHDHTai);
                    dbContext.SaveChanges();
                }
                else
                {
                    var lstCTHDHTai = dbContext.ChiTietHoaDon.Where(x => x.HoaDonId == hoaDon.HoaDonId).ToList();
                    var lstCTHDDelete = new List<ChiTietHoaDon>();
                    foreach(var chiTietHoaDon in lstCTHDHTai)
                    {
                        if(!hoaDon.ChiTietHoaDons.Any(x => x.HoaDonId == chiTietHoaDon.HoaDonId))
                        {
                            lstCTHDDelete.Add(chiTietHoaDon);
                        }
                        else
                        {
                            var chiTietMoi = hoaDon.ChiTietHoaDons.FirstOrDefault(x => x.HoaDonId == chiTietHoaDon.HoaDonId);
                            chiTietHoaDon.SanPhamId = chiTietMoi.SanPhamId;
                            chiTietHoaDon.SoLuong = chiTietMoi.SoLuong;
                            chiTietHoaDon.DonViTinh = chiTietMoi.DonViTinh;
                            var sp = dbContext.SanPham.FirstOrDefault(x => x.SanPhamId == chiTietMoi.SanPhamId);
                            chiTietHoaDon.ThanhTien = sp.GiaThanh * chiTietMoi.SoLuong;
                            dbContext.Update(chiTietHoaDon);
                            dbContext.SaveChanges();
                        }
                    }
                    dbContext.RemoveRange(lstCTHDDelete);
                    dbContext.SaveChanges();
                    foreach(var item in hoaDon.ChiTietHoaDons)
                    {
                        if(!lstCTHDHTai.Any(x => x.HoaDonId == item.HoaDonId))
                        {
                            item.HoaDonId = hoaDon.HoaDonId;
                            var sp = dbContext.SanPham.FirstOrDefault(x => x.SanPhamId == item.SanPhamId);
                            item.ThanhTien = sp.GiaThanh * item.SoLuong;
                            dbContext.Add(item);
                            dbContext.SaveChanges();
                        }
                    }
                }
                var tongTienMoi = dbContext.ChiTietHoaDon.Where(x => x.HoaDonId == hoaDon.HoaDonId).Sum(x => x.ThanhTien);
                hoaDon.TongTien = tongTienMoi;
                hoaDon.ThoiGianCapNhat = DateTime.Now;
                hoaDon.ChiTietHoaDons = null;
                dbContext.Update(hoaDon);
                dbContext.SaveChanges();
                trans.Commit();
                return ErrorMessage.ThanhCong;
            }
        }

        public string TaoMaGiaoDich()
        {
            var res = DateTime.Now.ToString("yyyyMMdd") + "_";
            var countSoGiaoDichHomNay = dbContext.HoaDon.Count(x => x.ThoiGianTao.Date == DateTime.Now.Date);
            if(countSoGiaoDichHomNay > 0)
            {
                int tmp = countSoGiaoDichHomNay + 1;
                if (tmp < 10)
                {
                    return res += "00" + tmp.ToString();
                }
                else if(tmp < 100)
                {
                    return res += "0" + tmp.ToString();
                }
                else
                {
                    return res += tmp.ToString();
                }
            }
            return res + "001";
        }

        public ErrorMessage ThemHoaDon(HoaDon hoaDon)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                hoaDon.ThoiGianTao = DateTime.Now;
                hoaDon.MaGiaoDich = TaoMaGiaoDich();

                var lstCTHD = hoaDon.ChiTietHoaDons;
                hoaDon.ChiTietHoaDons = null;

                dbContext.Add(hoaDon);
                dbContext.SaveChanges();

                foreach(var item in lstCTHD)
                {
                    if(dbContext.SanPham.Any(x => x.SanPhamId == item.SanPhamId))
                    {
                        item.HoaDonId = hoaDon.HoaDonId;
                        var sp = dbContext.SanPham.FirstOrDefault(x => x.SanPhamId == item.SanPhamId);
                        item.ThanhTien = item.SoLuong * sp.GiaThanh;
                        dbContext.Add(item);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        return ErrorMessage.SanPhamKhongTonTai;
                    }
                }
                hoaDon.TongTien = lstCTHD.Sum(x => x.ThanhTien);
                dbContext.SaveChanges();
                trans.Commit();
                return ErrorMessage.ThanhCong;
            }
        }

        public ErrorMessage XoaHoaDon(int hoaDonId)
        {
            if(dbContext.HoaDon.Any(x => x.HoaDonId == hoaDonId))
            {
                var hD = dbContext.HoaDon.Find(hoaDonId);
                var cthD = dbContext.ChiTietHoaDon.Find(hoaDonId);
                dbContext.Remove(cthD);
                dbContext.SaveChanges();

                dbContext.Remove(hD);
                dbContext.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.HoaDonKhongTonTai;
            }
        }
    }
}
