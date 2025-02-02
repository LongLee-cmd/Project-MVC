using QuanLySinhVien_Database_First.Models;
using System.ComponentModel.DataAnnotations;
namespace QuanLySinhVien_Database_First.Mymodel
{
    public class CHocVien
    {
        [Display(Name ="Mã Học Viên")]//Rename cột
        [Required(ErrorMessage ="Vui lòng nhập Mã số học viên!")]//Kiểm tra nhập hay chưa
        public string Mshv { get; set; } = null!;
        [Display(Name = "Tên Học Viên")]
        public string? Tenhv { get; set; }
        [Display(Name = " Ngày Sinh")]
        public DateTime? Ngaysinh { get; set; }
        [Display(Name = "Giới Tính")]
        public bool? Phai { get; set; }
        [Display(Name = "Mã Lớp")]

        public string? Malop { get; set; }
  
        public virtual Lop? MalopNavigation { get; set; }
        public static Lylich chuyendoi(CHocVien x)
        {
            return new Lylich
            {
                Mshv = x.Mshv,
                Tenhv = x.Tenhv,
                Ngaysinh = x.Ngaysinh,
                Phai = x.Phai,
                Malop = x.Malop
            };
        }
        public static CHocVien chuyendoi(Lylich x)
        {
            return new CHocVien
            {
                Mshv = x.Mshv,
                Tenhv = x.Tenhv,
                Ngaysinh = x.Ngaysinh,
                Phai = x.Phai,
                Malop = x.Malop
            };
        }
    }
}
