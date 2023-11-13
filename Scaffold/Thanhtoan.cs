using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("THANHTOAN")]
    public partial class Thanhtoan
    {
        [Key]
        [Column("magiaodich")]
        [StringLength(12)]
        public string Magiaodich { get; set; }

        [Required]
        [Column("mahd")]
        [StringLength(10)]
        public string Mahd { get; set; }
        [Required]
        [Column("manganhang")]
        [StringLength(5)]
        public string Manganhang { get; set; }
        [Required]
        [Column("makh")]
        [StringLength(7)]
        public string Makh { get; set; }
        [Column("trangthai")]
        [StringLength(20)]
        public string Trangthai { get; set; }
        
        [Column("ngaylap", TypeName = "date")]
        public DateTime ngaylap { get; set; }

        [ForeignKey(nameof(Mahd))]
        [InverseProperty(nameof(Hoadon.Thanhtoans))]
        public virtual Hoadon MahdNavigation { get; set; }

        [ForeignKey(nameof(Makh))]
        [InverseProperty(nameof(Khachhang.Thanhtoans))]
        public virtual Khachhang MakhNavigation { get; set; }
        [ForeignKey(nameof(Manganhang))]
        [InverseProperty(nameof(Hotrothanhtoan.Thanhtoans))]
        public virtual Hotrothanhtoan ManganhangNavigation { get; set; }
    }
}
