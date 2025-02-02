using System;
using System.Collections.Generic;

namespace QuanLySinhVien_Database_First.Models
{
    public partial class Monhoc
    {
        public Monhoc()
        {
            Diemthis = new HashSet<Diemthi>();
        }

        public string Msmh { get; set; } = null!;
        public string? Tenmh { get; set; }
        public int? Sotiet { get; set; }

        public virtual ICollection<Diemthi> Diemthis { get; set; }
    }
}
