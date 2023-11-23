using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using WebCosmetic.Scaffold;
using Microsoft.AspNetCore.Authorization;

namespace WebCosmetic.Admins.Role
{
    // nếu nhiều role cùng lúc thì user đó phải đáp ứng đủ tất cả các role, còn nhiều authorize đơn lẻ thì 1 trong số đó
    [Authorize(policy: "AdminTerm")]
    [Authorize(Roles = "Administrator")]
    [Authorize(Roles = "Administrator, Manager")]
    [Authorize(Roles = "Manager")]
    public class IndexModel : RolePageModel
    {   
        public IndexModel(RoleManager<IdentityRole> roleManager, QL_COSMETICContext _cosmeticContext) : base(roleManager, _cosmeticContext)
        {

        }

        // kế thừa class đã inject dịch vụ IdentityRole, và yourcontextmodel
      
        // danh sách các role
        // xây dụng lớp mở rộng từ RoleManager, thêm thuộc tính để xem các claims
        public class ClaimModel : IdentityRole
        {
            public string[] claims { get; set;}
            public List<IdentityRoleClaim<string>> Claims { get; set; }

        }

        public List<ClaimModel> _roles { get; set; }
        public async Task OnGet()
        {
            var role = _roleManager.Roles.ToList();
            _roles = new List<ClaimModel>();
            foreach(var r in role)
            {
                var getClaim = await _roleManager.GetClaimsAsync(r);
                var claimStrings = getClaim.Select(c=>c.Type + ": " + c.Value); 

                var claim = new ClaimModel()
                {
                    Name = r.Name,
                    Id = r.Id,
                    claims = claimStrings.ToArray()// not tolistx
                };
                // lấy id thông qua context
                claim.Claims = _cosmeticContext.RoleClaims.Where(c => c.RoleId == r.Id).ToList();
                _roles.Add(claim);
            }    
        }
        public void OnPost()
        {

            RedirectToPage();// về OnGet()
        }
    }
}
