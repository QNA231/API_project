﻿namespace ThemSuaXoaDuLieu.Entities
{
    public class SanPham
    {
        public int SanPhamId { get; set; }
        public int LoaiSanPhamId { get; set; }
        public string TenSanPham { get; set; }
        public double GiaThanh { get; set; }
        public string MoTa { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public string KyHieuSanPham { get; set; }
        public LoaiSanPham LoaiSanPham { get; set; }
        //public IEnumerable<ChiTietHoaDon> chiTietHoaDons { get; set; }
    }
}
