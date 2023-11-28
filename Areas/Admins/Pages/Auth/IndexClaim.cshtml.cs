using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using WebCosmetic.Models;
using WebCosmetic.Scaffold;

namespace WebCosmetic.Areas.Admins.Pages.User
{
    [Authorize(policy: "AdminTerm")]
    [Authorize(Roles = "Administrator")]
    public class IndexClaimModel : PageModel
    {
        DataTransfer data = new DataTransfer();
        private readonly UserManager<CosmeticModel> _userManager;
        private readonly QL_COSMETICContext _context;
        public string ReturnUrl { get; set; }
        public IndexClaimModel(UserManager<CosmeticModel> userManager,
        QL_COSMETICContext context)
        {
            this._userManager = userManager;
            this._context = context;
        }
        public CosmeticModel user { get; set; }

        public List<Profile> _usersProfile { get; set; }
        public class Profile
        {
            public string _maNv { get; set; }
            public string _loginid { get; set; }
            public string _tenNv { get; set; }
            public bool Official { get; set; } = false;
            public List<string> roles { get; set; } = new List<string>();
            public List<KeyValuePair<string, string>> roleClaims { get; set; } = new List<KeyValuePair<string, string>>();

        }
        public async Task<IActionResult> OngetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            var userList = _context.Nhanviens.ToList();
            this._usersProfile = new List<Profile>(userList.Count());
            foreach (var i in userList)
            {
                Profile p = new Profile();
                p._maNv = i.Manv;
                p._tenNv = i.Tennv;
                var result = await _userManager.FindByNameAsync(p._tenNv.Capitalize().VietnameseToEnglishChars());
                if (result != null)
                    p.Official = true;
                user = await _userManager.FindByIdAsync(data.GetLoginId(i.Manv));
                if(user != null)
                {
                    foreach (var role in (await _userManager.GetRolesAsync(user)).ToList())
                    {
                        p.roles.Add(role);
                    }
                    foreach (var claim in (await _userManager.GetClaimsAsync(user)).ToList())
                    {
                        p.roleClaims.Add(new KeyValuePair<string, string>(claim.Type, claim.Value));
                    }
                }  
                this._usersProfile.Add(p);
            }
            return Page();
        }

    }

}

