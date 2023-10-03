using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("DEXUATMUA")]
    public partial class Dexuatmua
    {
        [Key]
        [Column("masp")]
        [StringLength(10)]
        public string Masp { get; set; }

        [ForeignKey(nameof(Masp))]
        [InverseProperty(nameof(Sanpham.Dexuatmua))]
        public virtual Sanpham MaspNavigation { get; set; }
    }
}
