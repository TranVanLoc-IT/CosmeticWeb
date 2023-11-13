using WebCosmetic.Admins.Role;
using WebCosmetic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebCosmetic.Scaffold;
using System.Linq;

namespace WebCosmetic.Admins.claim
{
    public class DeleteRoleClaimsModel : RolePageModel
    {
        private readonly ILogger<DeleteRoleClaimsModel> logger;
        public DeleteRoleClaimsModel(ILogger<DeleteRoleClaimsModel> _logger, RoleManager<IdentityRole> roleManager, QL_COSMETICContext cosmeticContext) : base(roleManager, cosmeticContext)
        {
            logger = _logger;
        }
        // xác nhận tt claim bị xóa
        public IdentityRoleClaim<string> roleClaim { get; set; }
        public IdentityRole user { get; set; }
        public async Task<IActionResult> OnGet(int? claimid)
        {
            if (claimid == null) return Content("Error, not found this claim");

            roleClaim = _cosmeticContext.RoleClaims.Where(c => c.Id == claimid).FirstOrDefault();

            this.user = await _roleManager.FindByIdAsync(roleClaim.RoleId);

            var having = _cosmeticContext.RoleClaims.Any(c => c.Id == claimid);
            if(!having)
            {
                this.statusMessage = "Claim này không tồn tại";
                return Page();
            }    
            return Page();
        }
        public async Task<IActionResult> OnPostConfirmAsync(int ? claimid)
        {
            
            // cái cần tìm là claim id nên dùng _cosmeticContext chứ không phải _roleManager
            roleClaim = _cosmeticContext.RoleClaims.Where(c => c.Id == claimid).FirstOrDefault();

            this.user = await _roleManager.FindByIdAsync(roleClaim.RoleId);
            
            // new Claim() với giá trị đã tìm được vì tham số cần
            var isDeleted = await _roleManager.RemoveClaimAsync(this.user, new Claim(roleClaim.ClaimType,roleClaim.ClaimValue));

            if(isDeleted.Succeeded)
            {
                this.statusMessage = $"Remove claim has id {roleClaim.Id} successfully";
                logger.LogInformation("Deleted successed");
                return RedirectToPage("./Index");

            }
            logger.LogInformation("Deleted failed");

            this.statusMessage = $"Error: Remove claim has id {roleClaim.Id} failed";

            return Page();
        }
    }
}
