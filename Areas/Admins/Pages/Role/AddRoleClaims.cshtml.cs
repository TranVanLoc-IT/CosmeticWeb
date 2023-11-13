using WebCosmetic.Admins.Role;
using WebCosmetic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Principal;
using WebCosmetic.Scaffold;
using System.Threading.Tasks;
using System.Linq;

namespace WebCosmetic.Admins.claim
{
    // claim là các giá trị được ủy quyền sử dụng bởi role
    public class AddRoleClaimsModel : RolePageModel
    {
        public AddRoleClaimsModel(RoleManager<IdentityRole> roleManager, QL_COSMETICContext _cosmeticContext) : base(roleManager, _cosmeticContext)
        {
        }
        public class InputClaim
        {
            [DataType("text")]
            [Display(Name = "Nhập tên Claim: ")]
            [Required]
            [StringLength(20,ErrorMessage = "Ten claim phai dai tu {2} den {1}", MinimumLength = 3)]
            public string ClaimType { get; set; }

            [DataType("text")]
            [Required]
            [Display(Name = "Nhập giá trị Claim: ")]
            [StringLength(20, ErrorMessage = "Gia tri claim phai dai tu {2} den {1}", MinimumLength = 5)]
            public string ClaimValue { get; set; }
        }
        [BindProperty]
        public InputClaim input { get; set; }
        public IdentityRole role { get; set; }
        public async Task<IActionResult> OnGet(string roleid)
        {
            if(roleid==null)return BadRequest();
            role = await _roleManager.FindByIdAsync(roleid);
            if(role==null) return NotFound("Khong co role nay");

            return Page();
        }
        public async Task<IActionResult> OnPost(string roleid)
        {
            if (roleid == null) return BadRequest();
            role = await _roleManager.FindByIdAsync(roleid);
            if (role == null) return NotFound("Khong co role nay");

            var isValid = (await _roleManager.GetClaimsAsync(role)).Any(r => r.Type == input.ClaimType && r.Value == input.ClaimValue);
            if(!isValid)
            {
                // bắt đầu thêm claims
                var newClaims = new Claim(input.ClaimType, input.ClaimValue);
                var isSuccessed = await _roleManager.AddClaimAsync(role, newClaims);
                if(isSuccessed.Succeeded)
                {
                    this.statusMessage = $"Add claims for role {this.role.Name} successfully";
                    return RedirectToPage("./Index");
                }
                this.statusMessage = $"Add Claims {this.role.Name} failed, please try again !";
                
            }    
            else
            {
                ModelState.AddModelError("Lỗi", "Claim đã tồn tại");
                return Page();
            }    
            return RedirectToPage("./Index");
        }    
    }
}
