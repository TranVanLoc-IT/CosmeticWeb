using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("THONGBAO")]
    public partial class Thongbao
    {
        [Key]
        [Column("mask")]
        [StringLength(7)]
        public string Mask { get; set; }
        [Key]
        [Column("makh")]
        [StringLength(7)]
        public string Makh { get; set; }
        [Column("trangthai")]
        [StringLength(30)]
        public string Trangthai { get; set; }

        [ForeignKey(nameof(Makh))]
        [InverseProperty(nameof(Khachhang.Thongbaos))]
        public virtual Khachhang MakhNavigation { get; set; }
        [ForeignKey(nameof(Mask))]
        [InverseProperty(nameof(Sukien.Thongbaos))]
        public virtual Sukien MaskNavigation { get; set; }
    }
}
