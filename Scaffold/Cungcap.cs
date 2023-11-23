using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("CUNGCAP")]
    [Index(nameof(Masp), Name = "IX_CUNGCAP_masp")]
    public partial class Cungcap
    {
        [Key]
        [Column("macongty")]
        [StringLength(5)]
        public string Macongty { get; set; }
        [Key]
        [Column("masp")]
        [StringLength(10)]
        public string Masp { get; set; }
        [Key]
        [Column("ngaynhap", TypeName = "date")]
        public DateTime Ngaynhap { get; set; }
        [Column("soluongcc")]
        public int? Soluongcc { get; set; }

        [ForeignKey(nameof(Macongty))]
        [InverseProperty(nameof(Congty.Cungcaps))]
        public virtual Congty MacongtyNavigation { get; set; }
        [ForeignKey(nameof(Masp))]
        [InverseProperty(nameof(Sanpham.Cungcaps))]
        public virtual Sanpham MaspNavigation { get; set; }
    }
}
