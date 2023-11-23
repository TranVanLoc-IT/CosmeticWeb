using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Keyless]
    [Table("LOAISP")]
    public partial class Loaisp
    {
        [Column("maloai")]
        [StringLength(255)]
        public string Maloai { get; set; }
        [Column("tenloai")]
        [StringLength(255)]
        public string Tenloai { get; set; }
        [Column("macongty")]
        [StringLength(255)]
        public string Macongty { get; set; }
    }
}
