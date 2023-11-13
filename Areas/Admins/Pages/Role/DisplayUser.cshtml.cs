using WebCosmetic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace WebCosmetic.Admins.Role
{
    // đâu quản lí role nên ko inherit RolePageModel
    public class DisplayUserModel : PageModel
    {
        private readonly int USERS_PER_PAGE = 5;
        public readonly UserManager<CosmeticModel> _userManager;
        public DisplayUserModel(UserManager<CosmeticModel> userManager)
        {
            this._userManager = userManager;
        }
        public class UserAndRole : CosmeticModel
        {
            public string rolesName { get; set; }
            public string userClaims { get; set; }
            // mục đích lấy ra danh sách các role của từng user, nếu không chỉ còn cách gắn trùm là sai
        }
        
        // nhận trang hiện tại, chỉ hỗ trợ post
        [TempData]
        public string statusMessage { get; set; }

        [BindProperty(SupportsGet = true,Name = "p")]
        public int currentPage { get; set; }
        public int totalPage { get; set; }
        public List<UserAndRole> users { get; set; }
        public async Task OnGet()
        {
            // truy cập trang là có
            this.totalPage = (int)Math.Ceiling((double)this._userManager.Users.Count() / USERS_PER_PAGE);
            if (currentPage <= 1) currentPage = 1;
            var select = (from item in this._userManager.Users
                         orderby item.UserName ascending
                         select item).Skip(USERS_PER_PAGE*(currentPage-1)).Take(USERS_PER_PAGE)
                         .Select(s => new UserAndRole()
                         {
                             UserName = s.UserName,
                             Id= s.Id,
                         });
                        
            users = await select.ToListAsync();
            foreach(var item in users)
            {
                var c = await _userManager.GetClaimsAsync(item);
                var r = await this._userManager.GetRolesAsync(item);
                item.rolesName = string.Join(",", r);
                item.userClaims = string.Join(",", c);
            }    
        }
    }
}
