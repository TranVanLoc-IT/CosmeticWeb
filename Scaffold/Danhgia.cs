using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("DANHGIA")]
    public partial class Danhgia
    {
        [Key]
        [Column("masp")]
        [StringLength(10)]
        public string Masp { get; set; }
        [Key]
        [Column("maloai")]
        [StringLength(5)]
        public string Maloai { get; set; }
        [Column("sophanhoi")]
        public int? Sophanhoi { get; set; }
        [Column("sosao")]
        public int? Sosao { get; set; }

        [ForeignKey(nameof(Masp))]
        [InverseProperty(nameof(Sanpham.Danhgia))]
        public virtual Sanpham MaspNavigation { get; set; }
    }
}
