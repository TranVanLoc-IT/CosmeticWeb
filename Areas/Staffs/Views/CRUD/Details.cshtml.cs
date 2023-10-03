using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCosmetic.Scaffold;

namespace WebCosmetic.Areas_Staffs_Views_CRUD
{
    public class DetailsModel : PageModel
    {
        private readonly WebCosmetic.Scaffold.QL_COSMETICContext _context;

        public DetailsModel(WebCosmetic.Scaffold.QL_COSMETICContext context)
        {
            _context = context;
        }

        public Sanpham Sanpham { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sanpham = await _context.Sanphams
                .Include(s => s.MaloaiNavigation).FirstOrDefaultAsync(m => m.Masp == id);

            if (Sanpham == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
