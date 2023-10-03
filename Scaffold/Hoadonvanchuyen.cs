using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("HOADONVANCHUYEN")]
    public partial class Hoadonvanchuyen
    {
        [Key]
        [Column("magiaovan")]
        [StringLength(12)]
        public string Magiaovan { get; set; }
        [Required]
        [Column("madichvu")]
        [StringLength(4)]
        public string Madichvu { get; set; }
        [Required]
        [Column("mahd")]
        [StringLength(10)]
        public string Mahd { get; set; }
        [Column("khoangcach")]
        public double? Khoangcach { get; set; }
        [Column("tongthanhtoan", TypeName = "money")]
        public decimal? Tongthanhtoan { get; set; }

        [ForeignKey(nameof(Mahd))]
        [InverseProperty(nameof(Hoadon.Hoadonvanchuyens))]
        public virtual Hoadon MahdNavigation { get; set; }
    }
}
