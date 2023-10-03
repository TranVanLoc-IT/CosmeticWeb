using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("NHANVIEN")]
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Hoadons = new HashSet<Hoadon>();
            Sukiens = new HashSet<Sukien>();
        }

        [Key]
        [Column("manv")]
        [StringLength(7)]
        public string Manv { get; set; }
        [Required]
        [Column("tennv")]
        [StringLength(40)]
        public string Tennv { get; set; }
        [Column("ngaysinh", TypeName = "date")]
        public DateTime? Ngaysinh { get; set; }
        [Required]
        [Column("diachi")]
        [StringLength(50)]
        public string Diachi { get; set; }
        [Required]
        [Column("kinhnghiem")]
        [StringLength(50)]
        public string Kinhnghiem { get; set; }

        [InverseProperty(nameof(Hoadon.ManvNavigation))]
        public virtual ICollection<Hoadon> Hoadons { get; set; }
        [InverseProperty(nameof(Sukien.ManvNavigation))]
        public virtual ICollection<Sukien> Sukiens { get; set; }
    }
}
