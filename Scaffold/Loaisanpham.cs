using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("LOAISANPHAM")]
    [Index(nameof(Macongty), Name = "IX_LOAISANPHAM_macongty")]
    public partial class Loaisanpham
    {
        public Loaisanpham()
        {
            Dexuatkhuyenmais = new HashSet<Dexuatkhuyenmai>();
            Sanphams = new HashSet<Sanpham>();
        }

        [Key]
        [Column("maloai")]
        [StringLength(5)]
        public string Maloai { get; set; }
        [Required]
        [Column("tenloai")]
        [StringLength(50)]
        public string Tenloai { get; set; }
        [Required]
        [Column("macongty")]
        [StringLength(5)]
        public string Macongty { get; set; }

        [ForeignKey(nameof(Macongty))]
        [InverseProperty(nameof(Congty.Loaisanphams))]
        public virtual Congty MacongtyNavigation { get; set; }
        [InverseProperty(nameof(Dexuatkhuyenmai.MaloaiNavigation))]
        public virtual ICollection<Dexuatkhuyenmai> Dexuatkhuyenmais { get; set; }
        [InverseProperty(nameof(Sanpham.MaloaiNavigation))]
        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
