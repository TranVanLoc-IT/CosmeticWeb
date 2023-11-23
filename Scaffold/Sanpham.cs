using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("SANPHAM")]
    [Index(nameof(Maloai), Name = "IX_SANPHAM_maloai")]
    public partial class Sanpham
    {
        public Sanpham()
        {
            Chitiethoadons = new HashSet<Chitiethoadon>();
            Cungcaps = new HashSet<Cungcap>();
            Danhgia = new HashSet<Danhgium>();
            Dexuatkhuyenmais = new HashSet<Dexuatkhuyenmai>();
        }

        [Key]
        [Column("masp")]
        [Display(Name = "Mã sản phẩm: ")]
        [StringLength(10)]
        public string Masp { get; set; }
        [Required]
        [Display(Name = "Tên sản phẩm: ")]
        [Column("tensp")]
        [StringLength(100)]
        public string Tensp { get; set; }
        [Required]
        [Column("maloai")]
        [Display(Name = "Mã loại: ")]
        [StringLength(5)]
        public string Maloai { get; set; }
        [Display(Name = "Giá bán: ")]
        [Column("giaban", TypeName = "money")]
        public decimal? Giaban { get; set; }
        [Display(Name = "Ngày sản xuất")]
        [Column("nsx", TypeName = "date")]
        public DateTime? Nsx { get; set; }
        [Display(Name = "Hạn sử dụng: ")]
        [Column("hsd", TypeName = "date")]
        public DateTime? Hsd { get; set; }
        [Display(Name = "Giá bán mới: ")]
        [Column("giabanmoi", TypeName = "money")]
        public decimal? Giabanmoi { get; set; }
        [Column("solantruycap")]
        public int Solantruycap { get; set; }

        [Display(Name = "Mã loại: ")]
        [ForeignKey(nameof(Maloai))]
        [InverseProperty(nameof(Loaisanpham.Sanphams))]
        public virtual Loaisanpham MaloaiNavigation { get; set; }
        [InverseProperty("MaspNavigation")]
        public virtual Dexuatmua Dexuatmua { get; set; }
        [InverseProperty(nameof(Chitiethoadon.MaspNavigation))]
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
        [InverseProperty(nameof(Cungcap.MaspNavigation))]
        public virtual ICollection<Cungcap> Cungcaps { get; set; }
        [InverseProperty(nameof(Danhgium.MaspNavigation))]
        public virtual ICollection<Danhgium> Danhgia { get; set; }
        [InverseProperty(nameof(Dexuatkhuyenmai.MaspNavigation))]
        public virtual ICollection<Dexuatkhuyenmai> Dexuatkhuyenmais { get; set; }
    }
}
