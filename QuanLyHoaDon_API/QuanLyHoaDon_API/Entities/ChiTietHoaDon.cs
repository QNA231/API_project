namespace QuanLyHoaDon_API.Entities
{
    public class ChiTietHoaDon
    {
        public int ChiTietHoaDonId { get; set; }
        public int HoaDonId { get; set; }
        public int SanPhamId { get; set; }
        public int SoLuong { get; set; }
        public int DonViTinh { get; set; }
        public double? ThanhTien { get; set; }
        public HoaDon HoaDon { get; set; }
    }
}
