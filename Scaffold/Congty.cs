using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("CONGTY")]
    public partial class Congty
    {
        public Congty()
        {
            Cungcaps = new HashSet<Cungcap>();
            Loaisanphams = new HashSet<Loaisanpham>();
        }

        [Key]
        [Column("macongty")]
        [StringLength(5)]
        public string Macongty { get; set; }
        [Required]
        [Column("tencongty")]
        [StringLength(50)]
        public string Tencongty { get; set; }
        [Required]
        [Column("diachi")]
        [StringLength(50)]
        public string Diachi { get; set; }

        [InverseProperty(nameof(Cungcap.MacongtyNavigation))]
        public virtual ICollection<Cungcap> Cungcaps { get; set; }
        [InverseProperty(nameof(Loaisanpham.MacongtyNavigation))]
        public virtual ICollection<Loaisanpham> Loaisanphams { get; set; }
    }
}
