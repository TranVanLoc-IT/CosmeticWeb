using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("SUKIEN")]
    [Index(nameof(Manv), Name = "IX_SUKIEN_manv")]
    public partial class Sukien
    {
        public Sukien()
        {
            Thekhuyenmais = new HashSet<Thekhuyenmai>();
            Thongbaos = new HashSet<Thongbao>();
        }

        [Key]
        [Column("mask")]
        [StringLength(7)]
        public string Mask { get; set; }
        [Column("ngaybd", TypeName = "date")]
        public DateTime? Ngaybd { get; set; }
        [Column("ngaykt", TypeName = "date")]
        public DateTime? Ngaykt { get; set; }
        [Required]
        [Column("tensk")]
        [StringLength(50)]
        public string Tensk { get; set; }
        [Required]
        [Column("manv")]
        [StringLength(7)]
        public string Manv { get; set; }

        [ForeignKey(nameof(Manv))]
        [InverseProperty(nameof(Nhanvien.Sukiens))]
        public virtual Nhanvien ManvNavigation { get; set; }
        [InverseProperty(nameof(Thekhuyenmai.MaskNavigation))]
        public virtual ICollection<Thekhuyenmai> Thekhuyenmais { get; set; }
        [InverseProperty(nameof(Thongbao.MaskNavigation))]
        public virtual ICollection<Thongbao> Thongbaos { get; set; }
    }
}
