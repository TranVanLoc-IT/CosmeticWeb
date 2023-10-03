using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCosmetic.Scaffold;

namespace WebCosmetic.Areas_Staffs_Views_CRUD
{
    public class EditModel : PageModel
    {
        private readonly WebCosmetic.Scaffold.QL_COSMETICContext _context;

        public EditModel(WebCosmetic.Scaffold.QL_COSMETICContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["Maloai"] = new SelectList(_context.Loaisanphams, "Maloai", "Maloai");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sanpham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanphamExists(Sanpham.Masp))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SanphamExists(string id)
        {
            return _context.Sanphams.Any(e => e.Masp == id);
        }
    }
}
