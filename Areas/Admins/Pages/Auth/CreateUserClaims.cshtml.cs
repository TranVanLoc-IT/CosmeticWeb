using WebCosmetic.Admins.Role;
using WebCosmetic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCosmetic.Scaffold;

namespace WebCosmetic.Admins.claim
{
    public class CreateUserClaimsModel : PageModel
    {
        DataTransfer data = new DataTransfer();
        private readonly UserManager<CosmeticModel> _userManager;
        private readonly QL_COSMETICContext _cosmeticContext;
        public CreateUserClaimsModel(UserManager<CosmeticModel> userManager, QL_COSMETICContext cosmeticContext)
        {
            this._userManager = userManager;
            this._cosmeticContext = cosmeticContext;
        }
        [Display(Name = "Chọn role: ")]
        public SelectList dropRoleClaims { get; set; }
        public class InputUserClaims
        {
            
        }
        [BindProperty]
        public InputUserClaims inputClaims { get; set; }
        public CosmeticModel userClaims { get; set; }
        [TempData]
        public string statusMessage { get; set; }
        public async Task<IActionResult> OnGet(string id)
        {
            var roleClaimList =  _cosmeticContext.RoleClaims.ToList().Select(
                c => new SelectListItem
                {
                    Text = c.ClaimType,
                    Value = c.ClaimValue
                });

            this.dropRoleClaims = new SelectList(roleClaimList, "Value", "Text");
            if (id == null) { return NotFound("Not found this user"); }
            this.userClaims = await _userManager.FindByIdAsync(data.GetLoginId(id));

            if (userClaims == null) { return NotFound("Not found this user"); }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string id, string roleClaimId)
        {
            if (id == null) { return NotFound("Not found this user"); }
            // role -> roleManager
            // user -> userManager
            this.userClaims = await _userManager.FindByIdAsync(data.GetLoginId(id));
            if (userClaims == null) { return NotFound("Not found this user"); }
            var addClaims = _cosmeticContext.RoleClaims.Find(roleClaimId);
            var newClaim = new Claim(addClaims.ClaimType, addClaims.ClaimValue);
            var isAdded = await _userManager.AddClaimAsync(userClaims, newClaim);
            if (isAdded.Succeeded) {

                this.statusMessage = "User claims added successfully";
                return RedirectToPage("./index");
            }
            isAdded.Errors.ToList().ForEach(err =>
            {
                this.statusMessage = err.Description;
            });
            return Page();
        }
    }
}
