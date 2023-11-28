using WebCosmetic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;// dotnet add package Microsoft.AspNetCore.Mvc.ViewFeatures --version 2.0.0
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Linq;

namespace WebCosmetic.Admins.Auth
{
    public class DeleteUserRoleModel : PageModel
    {
        DataTransfer data = new DataTransfer();
        public readonly UserManager<CosmeticModel> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public DeleteUserRoleModel(UserManager<CosmeticModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        [BindProperty]
        [DisplayName("Chọn các quyền hiện có để xoá: ")]
        public string[] RolesName { get; set; }
        public CosmeticModel user { get; set; }
        public SelectList _listRoles { get; set; }
        [TempData]
        public string statusMessage { get; set; }
        public async Task<IActionResult> OnGet([FromRoute] string id)
        {
            if (id == null) return NotFound("Not found id user");
            this.user = await this._userManager.FindByIdAsync(data.GetLoginId(id));
            if (user == null) return NotFound("This user is not a official staff");
            var items = this._roleManager.Roles.Select(r => r.Name).ToList();
            this._listRoles = new SelectList(items);
            return Page();
        }
        public async Task<IActionResult> OnPost([FromRoute] string id)
        {
            if (id == null) return NotFound("Not found id user");
            this.user = await this._userManager.FindByIdAsync(id);
            if (user == null)
            {
                statusMessage = "Error: Người này hiện chưa là nhân viên";
                return Page();
            }
            var resDel = await this._userManager.RemoveFromRolesAsync(user, RolesName);
            if (resDel.Succeeded)
            {
                this.statusMessage = $"Update {this.user.UserName} roles successfully";
                return Page();
            }
            else
            {
                resDel.Errors.ToList().ForEach(err =>
                {
                    this.statusMessage = err.Description;
                });
            }
            return Page();
        }
    }
}
