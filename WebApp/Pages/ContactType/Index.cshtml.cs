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
    public class IndexModel : PageModel
    {
        private readonly WebApp.Data.INTEC_AGU_OCT22Context _context;

        public IndexModel(WebApp.Data.INTEC_AGU_OCT22Context context)
        {
            _context = context;
        }

        public IList<Entities.ContactType> ContactType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ContactType != null)
            {
                ContactType = await _context.ContactType.ToListAsync();
            }
        }
    }
}
