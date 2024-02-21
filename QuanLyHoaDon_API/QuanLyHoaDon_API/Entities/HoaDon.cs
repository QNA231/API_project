namespace QuanLyHoaDon_API.Entities
{
    public class HoaDon
    {
        public int HoaDonId { get; set; }
        public int? KhachHangId { get; set; }
        public string TenHoaDon { get; set; }
        public string MaGiaoDich { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public string? GhiChu { get; set; }
        public double? TongTien { get; set; }
        public IEnumerable<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
