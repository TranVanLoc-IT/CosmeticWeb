using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebCosmetic.Models
{
    public class CurrentUser:PageModel
    {
        public static string UserId { get; set; }
        private UserManager<CosmeticModel> _userManager { get; set; }
        private SignInManager<CosmeticModel> _signinManager { get; set; }
        public CurrentUser(UserManager<CosmeticModel> userManager, SignInManager<CosmeticModel> signInManager)
        {
            this._userManager = userManager;
            this._signinManager = signInManager;
            UserId = GetUserId();
        }
        public string GetUserId()
        {
            if(_signinManager.IsSignedIn(User))
            {
                return _userManager.GetUserId(User);
            }

            return "ma rong";
        }
    }
}
