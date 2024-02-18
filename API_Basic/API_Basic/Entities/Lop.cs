using System.ComponentModel.DataAnnotations;

namespace API_Basic.Entities
{
    public class Lop
    {
        public int LopId { get; set; }
        [Required]
        [MaxLength(10)]
        public string TenLop { get; set; }
        public int SiSo { get; set; }
        [MaxLength(20, ErrorMessage = "Moi lop chi co toi da 20 hoc sinh!")]
        public IEnumerable<HocSinh> DanhSachHocSinh { get; set; }
        public void NhapThongTinLop()
        {
            LopId = 0;
            Console.WriteLine("Nhap ten lop: ");
            TenLop = Console.ReadLine();
            SiSo = 0;
        }
    }
}
