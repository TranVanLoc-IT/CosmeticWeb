using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("THANHTOAN")]
    [Index(nameof(Mahd), Name = "IX_THANHTOAN_mahd")]
    [Index(nameof(Makh), Name = "IX_THANHTOAN_makh")]
    [Index(nameof(Manganhang), Name = "IX_THANHTOAN_manganhang")]
    public partial class Thanhtoan
    {
        [Key]
        [Display(Name = "Mã giao dịch: ")]
        [Column("magiaodich")]
        [StringLength(12)]
        public string Magiaodich { get; set; }
        [Required]
        [Column("manganhang")]
        [Display(Name = "Mã ngân hàng: ")]
        [StringLength(5)]
        public string Manganhang { get; set; }
        [Required]
        [Display(Name = "Mã khách hàng: ")]
        [Column("makh")]
        [StringLength(7)]
        public string Makh { get; set; }
        [Display(Name = "Trạng thái: ")]
        [Column("trangthai")]
        [StringLength(20)]
        public string Trangthai { get; set; }
        [Column("ngaylap", TypeName = "date")]
        [Display(Name = "Ngày lập: ")]
        public DateTime Ngaylap { get; set; }
        [Required]
        [Column("mahd")]
        [StringLength(10)]
        public string Mahd { get; set; }

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
