using WebCosmetic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;
using WebCosmetic.Scaffold;
using System.Linq;

namespace WebCosmetic.Admins.Auth
{
    public class DeleteUserClaimsModel : PageModel
    {
        private readonly UserManager<CosmeticModel> _userManager;

        private readonly QL_COSMETICContext _cosmeticContext;
        public IdentityUserClaim<string> claim { get; set; }

        public DeleteUserClaimsModel(UserManager<CosmeticModel> userManager, QL_COSMETICContext cosmeticContext)
        {
            this._userManager = userManager;
            this._cosmeticContext = cosmeticContext;
        }
        [TempData]
        public string claimType { get; set; }
        [TempData]
        public string statusMessage { get; set; }
        public CosmeticModel user { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            if (id == null) return NotFound("Khong tim thay claim id may");
            this.claim = _cosmeticContext.UserClaims.Where(c => c.Id == id).FirstOrDefault();
            if (this.claim == null) return NotFound("khong thay claim");

            this.user = await _userManager.FindByIdAsync(this.claim.UserId);
            if (this.user == null) return NotFound("khong tim thay user");

            return Page();
        }
        public async Task<IActionResult> OnPost(int? id)
        {
            if (id == null) return NotFound("Khong tim thay claim id may");
            this.claim = _cosmeticContext.UserClaims.Where(c => c.Id == id).FirstOrDefault();
            if (this.claim == null) return NotFound("khong thay claim");

            this.user = await _userManager.FindByIdAsync(this.claim.UserId);
            if (this.user == null) return NotFound("khong tim thay user");
            var result = await this._userManager.RemoveClaimAsync(this.user, new Claim(this.claim.ClaimType, this.claim.ClaimValue));
            if(result.Succeeded)
            {
                this.statusMessage = "Xóa thành công claim";
                return Page();
            }
            result.Errors.ToList().ForEach(err =>
            {
                this.statusMessage = err.Description;
            });
            return Page();
        }
    }
}
