using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCosmetic.Scaffold;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace WebCosmetic.Areas_Staffs_Views_CRUD
{
    // dotnet aspnet-codegenerator razorpage -m namespace.model -dc namespace.contextmodel -outDir dir/folder -udl --referenceScriptLibraries
    // [Authorize(policy:"staffTerm")]
    [Authorize(policy:"StaffTerm")]
    [Authorize(Roles = "Staff")]
    [Authorize(Roles = "Saler")]
    [Route("/edit-product/[action]")]
    public class IndexModel : PageModel
    {
        private readonly WebCosmetic.Scaffold.QL_COSMETICContext _context;
        public IList<Sanpham> Sanpham { get;set; }
        public IndexModel(WebCosmetic.Scaffold.QL_COSMETICContext context)
        {
            _context = context;
        }


        [Route("/xem-danh-sach-san-pham/")]
        public async Task OnGetAsync()
        {
            Sanpham = await _context.Sanphams
                .Include(s => s.MaloaiNavigation).ToListAsync();
        }
    }
}
