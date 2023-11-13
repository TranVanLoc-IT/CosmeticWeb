using WebCosmetic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Threading.Tasks;
using WebCosmetic.Scaffold;

namespace WebCosmetic.Admins.Role
{
    public class UpdateModel : RolePageModel
    {
        public UpdateModel(RoleManager<IdentityRole> roleManager, QL_COSMETICContext _cosmeticContext) : base(roleManager, _cosmeticContext)
        {

        }
        public class InputModel
        {
            [DataType(DataType.Text)]
            [Required]
            [StringLength(20, ErrorMessage = "Chieu dai ten role phai tu {2} đến {1}", MinimumLength = 5)]
            [DisplayName("Nhập tên role mới:  ")]
            public string _roleName { get; set; }
        }

        [BindProperty]
        public InputModel input { get; set; }
        public async Task<IActionResult> OnGet([FromRoute]string id)
        {
            // khi link trong index.cshtml method = get cung cấp roleid, nhưng trong trang form method = post thì nó ko có roleid
            // kiểm tra ngay từ đầu get từ trang index đến
            // xử lý cho roleid
            if (id == null) return NotFound("Khong tim thay id nay");
            var find = await _roleManager.FindByIdAsync(id);
            if (find != null)
            {
                return Page();
            }
            return NotFound("Loi cap nhat");

        }
        public async Task<IActionResult> OnPost([FromRoute]string id)
        {
            var newrole = new IdentityRole();
            if (id == null) return NotFound("Khong tim thay id nay");
            // gán newrole.Id = id sẽ bị lỗi. xem như 1 role mới chứ ko phải role cũ đã tồn tại, do đó cập nhật sai
            newrole = await _roleManager.FindByIdAsync(id);
            newrole.Name = input._roleName;
            var result = await _roleManager.UpdateAsync(newrole);
            if (result.Succeeded)
            {
                this.statusMessage = "Update role name successfully";
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
