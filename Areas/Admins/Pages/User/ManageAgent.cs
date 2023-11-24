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
    [Authorize(policy: "adminTerm")]
    [Authorize(Roles = "Administrator")]
    public class ManageAgentModel : PageModel
    {
        private readonly UserManager<CosmeticModel> _userManager;
        private readonly QL_COSMETICContext _context;
        public string ReturnUrl { get; set; }
        public ManageAgentModel(UserManager<CosmeticModel> userManager,
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
            public bool Official { get; set; } = false;

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
                this._usersProfile.Add(p);
            }
            return Page();
        }

        public async Task<IActionResult> OnpostAddLoginAsync(string _maNv, string _tenNv, string returnUrl = null)
        {
            _tenNv = _tenNv.Capitalize().VietnameseToEnglishChars();
            string password = _maNv + _tenNv;
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new CosmeticModel { UserName = _tenNv ?? "Cosmetic Customer", Email = password + "@gmail.com" };
                var result = await _userManager.SetLockoutEnabledAsync(user, false);
                result = await _userManager.CreateAsync(user, password+'@');
                if (!result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return await OngetAsync(returnUrl);
        }
        public async Task<IActionResult> OnpostDelLoginAsync(string _tenNv, string returnUrl = null)
        {
            var user = await _userManager.FindByNameAsync(_tenNv.Capitalize().VietnameseToEnglishChars());
            if (user != null)
            {
                var res = await _userManager.DeleteAsync(user);
                if (res.Succeeded)
                    return await OngetAsync(returnUrl);
            }
            return NotFound("Not found this user");
        }
    }

    public static class ExpandStringmethod
    {
        public static string Capitalize(this string input)
        {
            string replace = "";
            replace += input[0] > 97 ? (char)(input[0] - 32) : input[0];
            for (int i = 1; i < input.Length - 1; i++)
            {

                if (input[i] == ' ' && input[i + 1] > 97)
                {
                    replace += (char)(input[++i] - 32);
                    continue;
                }
                if (input[i] == ' ')
                {
                    continue;
                }
                replace += input[i];
            }
            replace += input.Last();
            return replace;
        }
        public static string VietnameseToEnglishChars(this string input)
        {
            Dictionary<char, string> convert = new Dictionary<char, string>
        {
            {'đ',"d" },
            {'á',"as" },
            {'ê',"ee" },
            {'ễ',"e" },
            {'à',"a" },
            {'ỏ',"o" },
            {'ô',"o" },
            {'ộ',"o" },
            {'ò',"o" },
            {'ầ',"a" },
            {'â',"a" },
            {'ẹ',"e" },
            {'í',"i" },
            {'ị',"i" },
            {'ú',"u" },
            {'ự',"u" },
            {'ụ',"u" },
            {'ọ',"o" },
            {'ă',"a" },
            {'ẻ',"e" },
            {'ế',"e" },
            {'ạ',"a" },
             {'Đ',"D" },
            {'Á',"A" },
            {'Ê',"E" },
            {'À',"A" },
            {'Ỏ',"O" },
            {'Ô',"O" },
            {'Ẹ',"E" },
            {'Í',"I" },
            {'Ọ',"O" },
            {'Ụ',"U" },
            {'Ẻ',"E" },
            {'Ế',"E" },
            {'Ạ',"A" }
            // only convert for color string
        };
            string result = "";
            foreach (char c in input)
            {
                if (convert.ContainsKey(c))
                    result += convert[c];
                else
                    result += c;
            }
            return result;
        }
    }
}

