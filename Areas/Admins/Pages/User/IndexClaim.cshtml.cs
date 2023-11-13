using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebCosmetic.Models;
using WebCosmetic.Scaffold;

namespace WebCosmetic.Areas.Admins.Pages.User
{
    [Authorize(policy: "adminTerm")]
    [Authorize(Roles = "Administrator, Editor")]
    [Authorize(Roles = "Administrator")]
    [Authorize(Roles = "Manager")]
    public class IndexClaimModel : PageModel
    {
        private readonly UserManager<CosmeticModel> _userManager;
        private readonly QL_COSMETICContext _context;
        public IndexClaimModel(UserManager<CosmeticModel> userManager,
                                QL_COSMETICContext context)
        {
            this._userManager = userManager;
            this._context = context;
        }
        public List<Profile> _usersProfile { get; set; }
        public class Profile
        {
            public string _maNv { get; set; }
            public string _tenNv { get; set; }
            public List<string> roles { get; set; } = new List<string>();
            public List<KeyValuePair<string, string>> roleClaims { get; set; } = new List<KeyValuePair<string, string>>();

        }
       
        public async Task<IActionResult> OngetAsync()
        {
            var userList = _context.Nhanviens.ToList();
            this._usersProfile = new List<Profile>(userList.Count());
            foreach(var i in userList)
            {
                Profile p = new Profile();
                p._maNv = i.Manv;
                p._tenNv = i.Tennv;
                foreach(var role in _context.GetProfileRolesProcedure(i.Manv))
                {
                    p.roles.Add(role.Name);
                }    
                foreach(var claim in _context.GetProfileRoleClaimsProcedure(i.Manv))
                {
                    KeyValuePair<string, string> values = new KeyValuePair<string, string>(claim.ClaimType, claim.ClaimValue);
                    p.roleClaims.Add(values);
                }
                this._usersProfile.Add(p);
            }
            return Page();
        }
    }
}
