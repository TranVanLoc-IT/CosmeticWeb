using WebCosmetic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebCosmetic.Scaffold;

namespace WebCosmetic.Admins.Role
{
    public class RolePageModel:PageModel
    {
        protected readonly RoleManager<IdentityRole> _roleManager;

        protected readonly QL_COSMETICContext _cosmeticContext;
        // statusmessage thông báo thay đổi dịch vụ
        [TempData]
        public string statusMessage { get; set; }
        public RolePageModel(RoleManager<IdentityRole> roleManager, QL_COSMETICContext cosmeticContext)
        {
            this._roleManager = roleManager;
            this._cosmeticContext = cosmeticContext;
        }
    }
}
