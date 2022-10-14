﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Data;
using WebApp.Entities;

namespace WebApp.Pages.User
{
    public class CreateModel : PageModel
    {
        private readonly WebApp.Data.INTEC_AGU_OCT22Context _context;

        public CreateModel(WebApp.Data.INTEC_AGU_OCT22Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PeopleId"] = new SelectList(_context.People, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Entities.User User { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
