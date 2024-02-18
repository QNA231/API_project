using API_Basic.Constant;
using API_Basic.Entities;

namespace API_Basic.IServices
{
    public interface IHocSinhServices
    {
        ErrorMessage ThemHocSinh(HocSinh hs, int lopId);
        ErrorMessage SuaHocSinh(int HocSinhId);
        ErrorMessage XoaHocSinh(int HocSinhId);
        ErrorMessage ChuyenLopHocSinh(int HocSinhId, int lopMoiId);
        IEnumerable<HocSinh> GetDsHocSinh();
    }
}
