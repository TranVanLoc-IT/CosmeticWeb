using WebCosmetic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Threading.Tasks;
using WebCosmetic.Scaffold;
using System.Linq;

namespace WebCosmetic.Admins.Role
{
    public class DeleteModel : RolePageModel
    {
        public DeleteModel(RoleManager<IdentityRole> roleManager, QL_COSMETICContext cosmeticContext) : base(roleManager, cosmeticContext)
        {
        }
        public async Task<IActionResult> OnGet([FromRoute]string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound("Thieu thong tin cung cap hoac id khong ton tai");
            var result=await _roleManager.FindByIdAsync(id);
            if(result == null)
            {   
                return NotFound("Khong co role nay");
            }    

            return Page();
        }
        public async Task<IActionResult> OnPost([FromRoute] string id)
        {
            if (id == null) return NotFound("Thieu thong tin cung cap hoac id khong ton tai");
            var result = await _roleManager.FindByIdAsync(id);
            if (result == null)
            {
                return NotFound("Khong co role nay");
            }
            var del =await _roleManager.DeleteAsync(result);
            if (del.Succeeded)
            {
                this.statusMessage = "Xoa thanh cong role co ten: " + result.Name;
                return RedirectToPage("./Index", new { statusMessage = this.statusMessage});
            }
            del.Errors.ToList().ForEach(x =>
            {
                this.statusMessage = x.Description;
            });
            return Page();
        }

    }
}
