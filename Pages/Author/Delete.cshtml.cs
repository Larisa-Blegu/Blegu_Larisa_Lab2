﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Blegu_Larisa_lab2.Data;
using Blegu_Larisa_lab2.Models;

namespace Blegu_Larisa_lab2.Pages.Author
{
    public class DeleteModel : PageModel
    {
        private readonly Blegu_Larisa_lab2.Data.Blegu_Larisa_lab2Context _context;

        public DeleteModel(Blegu_Larisa_lab2.Data.Blegu_Larisa_lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Blegu_Larisa_lab2.Models.Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Author == null)
            {
                return NotFound();
            }

            var author = await _context.Author.FirstOrDefaultAsync(m => m.ID == id);

            if (author == null)
            {
                return NotFound();
            }
            else 
            {
                Author = author;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Author == null)
            {
                return NotFound();
            }
            var author = await _context.Author.FindAsync(id);

            if (author != null)
            {
                Author = author;
                _context.Author.Remove(Author);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}