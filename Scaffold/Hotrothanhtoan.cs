using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("HOTROTHANHTOAN")]
    public partial class Hotrothanhtoan
    {
        public Hotrothanhtoan()
        {
            Thanhtoans = new HashSet<Thanhtoan>();
        }

        [Key]
        [Column("manganhang")]
        [StringLength(5)]
        public string Manganhang { get; set; }
        [Required]
        [Column("tennganhang")]
        [StringLength(50)]
        public string Tennganhang { get; set; }
        [Column("diachi")]
        [StringLength(50)]
        public string Diachi { get; set; }

        [InverseProperty(nameof(Thanhtoan.ManganhangNavigation))]
        public virtual ICollection<Thanhtoan> Thanhtoans { get; set; }
    }
}
