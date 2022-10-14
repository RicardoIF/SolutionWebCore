using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Entities;

namespace WebApp.Pages.Departament
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp.Data.INTEC_AGU_OCT22Context _context;

        public DeleteModel(WebApp.Data.INTEC_AGU_OCT22Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Deparment Deparment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Deparment == null)
            {
                return NotFound();
            }

            var deparment = await _context.Deparment.FirstOrDefaultAsync(m => m.Id == id);

            if (deparment == null)
            {
                return NotFound();
            }
            else 
            {
                Deparment = deparment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Deparment == null)
            {
                return NotFound();
            }
            var deparment = await _context.Deparment.FindAsync(id);

            if (deparment != null)
            {
                Deparment = deparment;
                _context.Deparment.Remove(Deparment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
