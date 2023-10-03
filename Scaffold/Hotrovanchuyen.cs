using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Table("HOTROVANCHUYEN")]
    public partial class Hotrovanchuyen
    {
        [Key]
        [Column("madichvu")]
        [StringLength(4)]
        public string Madichvu { get; set; }
        [Required]
        [Column("tendichvu")]
        [StringLength(40)]
        public string Tendichvu { get; set; }
        [Column("chiphi", TypeName = "money")]
        public decimal? Chiphi { get; set; }
    }
}
