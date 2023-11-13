using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCosmetic.Scaffold;

namespace WebCosmetic.Areas_Staffs_Views_CRUD
{
    public class CreateModel : PageModel
    {
        private readonly WebCosmetic.Scaffold.QL_COSMETICContext _context;

        public CreateModel(WebCosmetic.Scaffold.QL_COSMETICContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Maloai"] = new SelectList(_context.Loaisanphams, "Maloai", "Maloai");
            return Page();
        }

        [BindProperty]
        public Sanpham Sanpham { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sanphams.Add(Sanpham);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
