using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("THEKHUYENMAI")]
    public partial class Thekhuyenmai
    {
        [Key]
        [Column("mathe")]
        [StringLength(7)]
        public string Mathe { get; set; }
        [Column("trangthai")]
        [StringLength(10)]
        public string Trangthai { get; set; }
        [Column("giatri")]
        public double? Giatri { get; set; }
        [Column("mask")]
        [StringLength(7)]
        public string Mask { get; set; }
        [Column("makh")]
        [StringLength(7)]
        public string Makh { get; set; }

        [ForeignKey(nameof(Makh))]
        [InverseProperty(nameof(Khachhang.Thekhuyenmais))]
        public virtual Khachhang MakhNavigation { get; set; }
        [ForeignKey(nameof(Mask))]
        [InverseProperty(nameof(Sukien.Thekhuyenmais))]
        public virtual Sukien MaskNavigation { get; set; }
    }
}
