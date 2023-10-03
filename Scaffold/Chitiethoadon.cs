using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("CHITIETHOADON")]
    public partial class Chitiethoadon
    {
        [Key]
        [Column("mahd")]
        [StringLength(10)]
        public string Mahd { get; set; }
        [Key]
        [Column("masp")]
        [StringLength(10)]
        public string Masp { get; set; }
        [Column("soluong")]
        public int? Soluong { get; set; }
        [Column("thanhtien", TypeName = "money")]
        public decimal? Thanhtien { get; set; }

        [ForeignKey(nameof(Mahd))]
        [InverseProperty(nameof(Hoadon.Chitiethoadons))]
        public virtual Hoadon MahdNavigation { get; set; }
        [ForeignKey(nameof(Masp))]
        [InverseProperty(nameof(Sanpham.Chitiethoadons))]
        public virtual Sanpham MaspNavigation { get; set; }
    }
}
