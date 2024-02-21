using API_Basic.Constant;
using API_Basic.Entities;
using API_Basic.IServices;
using Microsoft.EntityFrameworkCore;

namespace API_Basic.Services
{
    public class HocSinhServices : IHocSinhServices
    {
        private readonly AppDbContext DbContext;

        public HocSinhServices()
        {
            DbContext = new AppDbContext();
        }

        public ErrorMessage ChuyenLopHocSinh(int HocSinhId, int lopMoiId)
        {
            var hocSinh = DbContext.HocSinh.FirstOrDefault(x => x.HocSinhId == HocSinhId);
            if (hocSinh == null)
            {
                return ErrorMessage.HocSinhKhongTonTai;
            }
            var lopMoi = DbContext.Lop.FirstOrDefault(x => x.LopId == lopMoiId);
            if (lopMoi == null)
            {
                return ErrorMessage.LopKhongTonTai;
            }
            var lopCu = DbContext.Lop.FirstOrDefault(x => x.LopId == hocSinh.LopId);
            if (lopCu != null)
            {
                lopCu.SiSo -= 1;
            }
            lopMoi.SiSo += 1;
            hocSinh.LopId = lopMoi.LopId;
            DbContext.SaveChanges();
            return ErrorMessage.ThanhCong;
        }

        public PageResult<HocSinh> GetDanhSachHocSinh(string? keyword, Pagination pagination)
        {
            var dsHS = DbContext.HocSinh.Include(x => x.Lop).AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                dsHS = dsHS.Where(x => x.HoTen.ToLower().Contains(keyword.ToLower()));
            }
            var result = PageResult<HocSinh>.ToPageResult(pagination, dsHS);
            pagination.TotalCount = dsHS.Count();
            return new PageResult<HocSinh>(pagination, result);
        }

        public IEnumerable<HocSinh> GetDsHocSinh()
        {
            throw new NotImplementedException();
        }

        public ErrorMessage SuaHocSinh(int HocSinhId)
        {
            if (DbContext.HocSinh.Any(x => x.HocSinhId == HocSinhId))
            {
                var hocSinh = DbContext.HocSinh.Find(HocSinhId);
                //Console.WriteLine("Nhap ho ten: ");
                //hocSinh.HoTen = Console.ReadLine();
                //Console.WriteLine("Nhap ngay sinh: ");
                //hocSinh.NgaySinh = DateTime.Parse(Console.ReadLine());
                //Console.WriteLine("Nhap que quan: ");
                //hocSinh.QueQuan = Console.ReadLine();
                DbContext.Update(hocSinh);
                DbContext.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.ThatBai;
            }
        }

        public ErrorMessage ThemHocSinh(HocSinh hs, int lopId)
        {
            var lop = DbContext.Lop.FirstOrDefault(x => x.LopId == lopId);
            if (lop != null)
            {
                hs.Lop = null;
                hs.LopId = lopId;
                lop.SiSo += 1;
                DbContext.Add(hs);
                DbContext.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.ThatBai;
            }
        }

        public ErrorMessage XoaHocSinh(int HocSinhId)
        {
            if (DbContext.HocSinh.Any(x => x.HocSinhId == HocSinhId))
            {
                var hocSinh = DbContext.HocSinh.Find(HocSinhId);
                var lopht = DbContext.Lop.FirstOrDefault(x => x.LopId == hocSinh.LopId);
                lopht.SiSo -= 1;
                DbContext.Remove(hocSinh);
                DbContext.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.ThatBai;
            }
        }
    }
}
