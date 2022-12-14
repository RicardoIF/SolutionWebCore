using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Entities;

namespace WebApp.Pages.ContactType
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp.Data.INTEC_AGU_OCT22Context _context;

        public DeleteModel(WebApp.Data.INTEC_AGU_OCT22Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Entities.ContactType ContactType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ContactType == null)
            {
                return NotFound();
            }

            var contacttype = await _context.ContactType.FirstOrDefaultAsync(m => m.Id == id);

            if (contacttype == null)
            {
                return NotFound();
            }
            else 
            {
                ContactType = contacttype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ContactType == null)
            {
                return NotFound();
            }
            var contacttype = await _context.ContactType.FindAsync(id);

            if (contacttype != null)
            {
                ContactType = contacttype;
                _context.ContactType.Remove(ContactType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
