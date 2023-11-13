using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebCosmetic.Models
{
    public class ProfileRoleResult
    {
        [StringLength(100)]
        public string Name { get; set; }
        public virtual ICollection<ProfileRoleResult> ProfileRoleResults { get; set; }

    }
    public class ProfileRoleClaimResult
    {
        [StringLength(50)]
        public string ClaimType { get; set; }
        [StringLength(100)]
        public string ClaimValue { get; set; }
        public virtual ICollection<ProfileRoleClaimResult> ProfileRoleClaimResults { get; set; }
    }
}
