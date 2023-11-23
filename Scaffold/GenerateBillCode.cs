using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebCosmetic.Scaffold
{
    [Keyless]
    public partial class GenerateBillCode
    {
        [Column("new_id")]
        [StringLength(8)]
        public string NewId { get; set; }
    }
}
