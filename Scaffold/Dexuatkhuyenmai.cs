using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("DEXUATKHUYENMAI")]
    public partial class Dexuatkhuyenmai
    {
        [Key]
        [Column("masp")]
        [StringLength(10)]
        public string Masp { get; set; }
        [Key]
        [Column("maloai")]
        [StringLength(5)]
        public string Maloai { get; set; }

        [ForeignKey(nameof(Maloai))]
        [InverseProperty(nameof(Loaisanpham.Dexuatkhuyenmais))]
        public virtual Loaisanpham MaloaiNavigation { get; set; }
        [ForeignKey(nameof(Masp))]
        [InverseProperty(nameof(Sanpham.Dexuatkhuyenmais))]
        public virtual Sanpham MaspNavigation { get; set; }
    }
}
