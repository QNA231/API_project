using System.ComponentModel.DataAnnotations;

namespace API_Basic.Entities
{
    public class HocSinh
    {
        public int HocSinhId { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string HoTen { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        [RegularExpression(".*\\S+.*", ErrorMessage = "Que quan phai co it nhat 1 ten thanh pho")]
        public string QueQuan { get; set; }
        public int LopId { get; set; }
        public Lop Lop { get; set; }
        public void NhapThongTin()
        {
            HocSinhId = 0;
            Console.WriteLine("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.WriteLine("Nhap ngay sinh: ");
            NgaySinh = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Nhap que quan: ");
            QueQuan = Console.ReadLine();
        }
    }
}
