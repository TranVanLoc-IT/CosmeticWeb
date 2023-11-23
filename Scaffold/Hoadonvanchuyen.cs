using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("HOADONVANCHUYEN")]
    [Index(nameof(Mahd), Name = "IX_HOADONVANCHUYEN_mahd")]
    public partial class Hoadonvanchuyen
    {
        [Key] 
        public string Magiaovan { get; set; }
        [Required]
        [Display(Name = "Mã dịch vụ: ")]
        [Column("madichvu")]
        [StringLength(4)]
        public string Madichvu { get; set; }
        [Required]
        [Display(Name = "Mã hóa đơn: ")]
        [Column("mahd")]
        [StringLength(10)]
        public string Mahd { get; set; }
        [Column("khoangcach")]
        public double? Khoangcach { get; set; }
        [Column("tongthanhtoan", TypeName = "money")]
        public decimal? Tongthanhtoan { get; set; }
        [Display(Name = "Ngày đặt ")]
        [Column("ngaydathang")]
        public DateTime Ngaydathang { get; set; }
        [Column("ngaygiaohang")]
        [Display(Name = "Mã giao: ")]
        public DateTime Ngaygiaohang { get; set; }
        [Column("tinhtrang")]
        [StringLength(10)]
        public string Tinhtrang { get; set; }

        [ForeignKey(nameof(Mahd))]
        [InverseProperty(nameof(Hoadon.Hoadonvanchuyens))]
        public virtual Hoadon MahdNavigation { get; set; }
    }
}
