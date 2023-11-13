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
    public class UpdateRoleClaimsModel : RolePageModel
    {
        public UpdateRoleClaimsModel(RoleManager<IdentityRole> roleManager, QL_COSMETICContext _cosmeticContext) : base(roleManager, _cosmeticContext)
        {
        }
        public class InputClaim
        {
            [DataType("text")]
            [Display(Name = "Nhập tên Claim: ")]
            [Required]
            [StringLength(20, ErrorMessage = "Ten claim phai dai tu {2} den {1}", MinimumLength = 3)]
            public string ClaimType { get; set; }

            [DataType("text")]
            [Required]
            [Display(Name = "Nhập giá trị Claim: ")]
            [StringLength(20, ErrorMessage = "Gia tri claim phai dai tu {2} den {1}", MinimumLength = 5)]
            public string ClaimValue { get; set; }
        }
        [BindProperty]
        public InputClaim input { get; set; }
        public IdentityRoleClaim<string> roleclaim { get; set; }
        public async Task<IActionResult> OnGet(int? claimid)
        {
            if (claimid == null) return BadRequest();
            // sử dụng context mói có claimid
            roleclaim = _cosmeticContext.RoleClaims.Where(c => c.Id == claimid).FirstOrDefault();
            if (roleclaim == null) return NotFound("Không có role claim này");
            input = new InputClaim()
            {
                ClaimType = roleclaim.ClaimType, // loại claim - tên gắn liền với đặc tính
                ClaimValue = roleclaim.ClaimValue// giá trị role
            };
            return Page();
        }
        public async Task<IActionResult> OnPost(int? claimid)
        {
            if (claimid == null) return BadRequest();
            // sử dụng context mói có claimid
            roleclaim = _cosmeticContext.RoleClaims.Where(c => c.Id == claimid).FirstOrDefault();
            if (roleclaim == null) return NotFound("Không có role claim này");

            // kiểm tra idclaim, nếu dùng _roleManager chỉ thêm claim cho role chứ ko xác dịnh được id của claim
            var isValid = _cosmeticContext.RoleClaims.Any(r => r.ClaimType == input.ClaimType && r.ClaimValue == input.ClaimValue && r.Id == claimid);
            if (!isValid)
            {
                // bắt đầu thêm claims
                roleclaim.ClaimType = input.ClaimType;
                roleclaim.ClaimValue = input.ClaimValue;
                var isSuccessed = await _cosmeticContext.SaveChangesAsync();
                this.statusMessage = $"Update claims uccessfully";
                return RedirectToPage("./Index");
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
