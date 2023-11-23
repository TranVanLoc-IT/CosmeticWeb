using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("HOADON")]
    [Index(nameof(Manv), Name = "IX_HOADON_manv")]
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiethoadons = new HashSet<Chitiethoadon>();
            Hoadonvanchuyens = new HashSet<Hoadonvanchuyen>();
            Thanhtoans = new HashSet<Thanhtoan>();
        }

        [Key]
        [Display(Name = "Mã hóa đơn: ")]
        [Column("mahd")]
        [StringLength(10)]
        public string Mahd { get; set; }
        [Required]
        [Column("makh")]
        [StringLength(7)]
        public string Makh { get; set; }
        [Display(Name = "Tổng tiền: ")]
        [Column("tongtien", TypeName = "money")]
        public decimal? Tongtien { get; set; }
        [Column("manv")]
        [StringLength(7)]
        public string Manv { get; set; }
        [Column("ngaylap")]
        public DateTime Ngaylap { get; set; }

        [ForeignKey(nameof(Manv))]
        [InverseProperty(nameof(Nhanvien.Hoadons))]
        public virtual Nhanvien ManvNavigation { get; set; }
        [InverseProperty(nameof(Chitiethoadon.MahdNavigation))]
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
        [InverseProperty(nameof(Hoadonvanchuyen.MahdNavigation))]
        public virtual ICollection<Hoadonvanchuyen> Hoadonvanchuyens { get; set; }
        [InverseProperty(nameof(Thanhtoan.MahdNavigation))]
        public virtual ICollection<Thanhtoan> Thanhtoans { get; set; }
    }
}
