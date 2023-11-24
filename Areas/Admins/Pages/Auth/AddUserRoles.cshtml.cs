using WebCosmetic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;// dotnet add package Microsoft.AspNetCore.Mvc.ViewFeatures --version 2.0.0
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace WebCosmetic.Admins.Role
{
    public class AddUserRolesModel : PageModel
    {
        DataTransfer data = new DataTransfer();
        public readonly UserManager<CosmeticModel> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public AddUserRolesModel(UserManager<CosmeticModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        [BindProperty]
        [DisplayName("Chọn thêm quyền quản trị: ")]
        public string[] RolesName { get; set; }
        public CosmeticModel user { get; set; }
        public SelectList _listRoles { get; set; }
        [TempData]
        public string statusMessage { get; set; }
        public async Task<IActionResult> OnGet([FromRoute]string id)
        {
            if (id == null) return NotFound("Not found id user");
            this.user = await this._userManager.FindByIdAsync(data.GetLoginId(id));
            if (user == null) return NotFound("This user is not a official staff");
            var items = this._roleManager.Roles.Select(r => r.Name).ToList();
            this._listRoles=new SelectList(items);
            return Page();
        }
        public async Task<IActionResult> OnPost([FromRoute]string id)
        {
            if (id == null) return NotFound("Not found id user");
            this.user = await this._userManager.FindByIdAsync(data.GetLoginId(id));
            Console.WriteLine(data.GetLoginId(id));
            if (this.user == null)
            {
                statusMessage = "Error: Người này hiện chưa là nhân viên";
                return await OnGet(id);
            }
            // xác định các tùy chọn trong RolesName
            // OldRoleName: phân quyền cũ trước đó
            // addRole: role mới => thêm
            // deleteOldRole: ko nằm trong phân quyền cũ => xóa
            var currentRole = (await this._userManager.GetRolesAsync(this.user)).ToArray();
            var deleteRole = currentRole.Where(r=>!this.RolesName.Contains(r));// xoa cai cu khi trong moi khong co
            var addRole = this.RolesName.Where(r=>!currentRole.Contains(r));// them cai khong co trong cai cu
            // thao tac
            var resDel = await this._userManager.RemoveFromRolesAsync(this.user, deleteRole);
            var resAdd = await this._userManager.AddToRolesAsync(this.user, addRole);
            if(resDel.Succeeded && resAdd.Succeeded)
            {
                this.statusMessage = $"Update {this.user.UserName} roles successfully";
                return await OnGet(id);
            }
            else
            {
                    resDel.Errors.ToList().ForEach(err =>
                    {
                        this.statusMessage = err.Description;
                    });
            }
            return await OnGet(id);
        }
    }
}
