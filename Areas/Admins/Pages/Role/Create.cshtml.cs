using WebCosmetic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebCosmetic.Admins.Role;
using WebCosmetic.Scaffold;
using System.Threading.Tasks;
using System.Linq;

namespace WebCosmetic.Admins.Role
{
    public class CreateModel : RolePageModel
    {
        private readonly SignInManager<CosmeticModel> _signinManager;
        public CreateModel(SignInManager<CosmeticModel> signinManager, RoleManager<IdentityRole> roleManager, QL_COSMETICContext userContext) : base(roleManager, userContext)
        {
            this._signinManager = signinManager;
        }

        public void OnGet()
        {
        }

        public class InputModel
        {
            [DataType(DataType.Text)]
            [Required]
            [StringLength(20, ErrorMessage = "Chieu dai ten role phai tu {2} đến {1}", MinimumLength = 5)]
            [DisplayName("Nhập để thêm quyền hệ thống: ")]
            public string _roleName { get; set; }
        }

        [BindProperty]
        public InputModel input { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid) {
                this.statusMessage = "Error: Cannot create new role";

                return Page();
            }
            // tạo role mới
            var newrole = new IdentityRole();
            newrole.Name = input._roleName;
            var res = await _roleManager.CreateAsync(newrole);
            if(res.Succeeded)
            {
                this.statusMessage="Bạn đã toàn hoàn tất role:  " + newrole.Name;
                await this._signinManager.SignOutAsync();
                return RedirectToPage("./Index", new(statusMessage = this.statusMessage));
            }
            else
            {
                res.Errors.ToList().ForEach(x =>
                {
                    ModelState.AddModelError(string.Empty, x.Description);
                    this.statusMessage = x.Description;
                });
            }

            return Page();// create.cshtml
        }
    }
}
