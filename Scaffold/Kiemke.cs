using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("KIEMKE")]
    public partial class Kiemke
    {
        [Key]
        [Column("masp")]
        [StringLength(10)]
        public string Masp { get; set; }
        [Key]
        [Column("maloai")]
        [StringLength(5)]
        public string Maloai { get; set; }
        [Column("slconlai")]
        public int? Slconlai { get; set; }
        [Column("sldaban")]
        public int? Sldaban { get; set; }
        [Column("ngaykiemke", TypeName = "date")]
        public DateTime? Ngaykiemke { get; set; }
        [Column("tinhtrang")]
        [StringLength(10)]
        public string Tinhtrang { get; set; }
    }
}
