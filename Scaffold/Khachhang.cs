using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("KHACHHANG")]
    public partial class Khachhang
    {
        public Khachhang()
        {
            Thanhtoans = new HashSet<Thanhtoan>();
            Thekhuyenmais = new HashSet<Thekhuyenmai>();
            Thongbaos = new HashSet<Thongbao>();
        }

        [Key]
        [Column("makh")]
        [StringLength(7)]
        public string Makh { get; set; }
        [Required]
        [Column("tenkh")]
        [StringLength(40)]
        public string Tenkh { get; set; }
        [Column("sdt")]
        [StringLength(11)]
        public string Sdt { get; set; }
        [Column("email")]
        [StringLength(40)]
        public string Email { get; set; }
        [Column("ngaysinh", TypeName = "date")]
        public DateTime? Ngaysinh { get; set; }

        [InverseProperty("MakhNavigation")]
        public virtual Nhanthongbao Nhanthongbao { get; set; }
        [InverseProperty(nameof(Thanhtoan.MakhNavigation))]
        public virtual ICollection<Thanhtoan> Thanhtoans { get; set; }
        [InverseProperty(nameof(Thekhuyenmai.MakhNavigation))]
        public virtual ICollection<Thekhuyenmai> Thekhuyenmais { get; set; }
        [InverseProperty(nameof(Thongbao.MakhNavigation))]
        public virtual ICollection<Thongbao> Thongbaos { get; set; }
    }
}
