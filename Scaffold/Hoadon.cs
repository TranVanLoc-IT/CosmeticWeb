using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("HOADON")]
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiethoadons = new HashSet<Chitiethoadon>();
            Hoadonvanchuyens = new HashSet<Hoadonvanchuyen>();
            Thanhtoans = new HashSet<Thanhtoan>();
        }

        [Key]
        [Column("mahd")]
        [StringLength(10)]
        public string Mahd { get; set; }
        [Required]
        [Column("makh")]
        [StringLength(7)]
        public string Makh { get; set; }
        [Column("tongtien", TypeName = "money")]
        public decimal? Tongtien { get; set; }
        [Required]
        [Column("manv")]
        [StringLength(7)]
        public string Manv { get; set; }
        [Column("ngaylap")]
        [DataType(dataType: DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime NgayLap { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Manv))]
        [InverseProperty(nameof(Nhanvien.Hoadons))]
        public virtual Nhanvien ManvNavigation { get; set; }


        [InverseProperty(nameof(Thanhtoan.MahdNavigation))]
        public virtual ICollection<Thanhtoan> Thanhtoans { get; set; }

        [InverseProperty(nameof(Chitiethoadon.MahdNavigation))]
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
        [InverseProperty(nameof(Hoadonvanchuyen.MahdNavigation))]
        public virtual ICollection<Hoadonvanchuyen> Hoadonvanchuyens { get; set; }
    }
}
