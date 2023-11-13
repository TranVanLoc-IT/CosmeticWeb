using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("SANPHAM")]
    public partial class Sanpham
    {
        public Sanpham()
        {
            Chitiethoadons = new HashSet<Chitiethoadon>();
            Cungcaps = new HashSet<Cungcap>();
            Danhgia = new HashSet<Danhgia>();
            Dexuatkhuyenmais = new HashSet<Dexuatkhuyenmai>();
        }

        [Key]
        [Display(Name = "Mã sản phẩm")]
        [Column("masp")]
        [StringLength(10)]
        public string Masp { get; set; }
        [Required]
        [Display(Name = "Tên sản phẩm")]
        [Column("tensp")]
        [StringLength(100)]
        public string Tensp { get; set; }
        [Required]
        [Display(Name = "Mã loại")]
        [Column("maloai")]
        [StringLength(5)]
        public string Maloai { get; set; }
        [Display(Name = "Giá bán")]
        [Column("giaban", TypeName = "money")]
        public decimal? Giaban { get; set; }
        [Display(Name = "Ngày sản xuất")]
        [Column("nsx", TypeName = "date")]
        public DateTime? Nsx { get; set; }
        [Column("hsd", TypeName = "date")]
        [Display(Name = "Hạn sử dụng")]
        public DateTime? Hsd { get; set; }

        [ForeignKey(nameof(Maloai))]
        [InverseProperty(nameof(Loaisanpham.Sanphams))]
        [Display(Name = "Mã loại")]
        public virtual Loaisanpham MaloaiNavigation { get; set; }
        [InverseProperty("MaspNavigation")]
        public virtual Dexuatmua Dexuatmua { get; set; }
        [InverseProperty(nameof(Chitiethoadon.MaspNavigation))]
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
        [InverseProperty(nameof(Cungcap.MaspNavigation))]
        public virtual ICollection<Cungcap> Cungcaps { get; set; }
        [InverseProperty(nameof(Scaffold.Danhgia.MaspNavigation))]
        public virtual ICollection<Danhgia> Danhgia { get; set; }
        [InverseProperty(nameof(Dexuatkhuyenmai.MaspNavigation))]
        public virtual ICollection<Dexuatkhuyenmai> Dexuatkhuyenmais { get; set; }
    }
}
