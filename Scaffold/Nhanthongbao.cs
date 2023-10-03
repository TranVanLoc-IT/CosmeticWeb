using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("NHANTHONGBAO")]
    public partial class Nhanthongbao
    {
        [Key]
        [Column("makh")]
        [StringLength(7)]
        public string Makh { get; set; }
        [Column("ngaydk", TypeName = "date")]
        public DateTime Ngaydk { get; set; }

        [ForeignKey(nameof(Makh))]
        [InverseProperty(nameof(Khachhang.Nhanthongbao))]
        public virtual Khachhang MakhNavigation { get; set; }
    }
}
