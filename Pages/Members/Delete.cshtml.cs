﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Blegu_Larisa_lab2.Data;
using Blegu_Larisa_lab2.Models;

namespace Blegu_Larisa_lab2.Pages.Members
{
    public class DeleteModel : PageModel
    {
        private readonly Blegu_Larisa_lab2.Data.Blegu_Larisa_lab2Context _context;

        public DeleteModel(Blegu_Larisa_lab2.Data.Blegu_Larisa_lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.ID == id);

            if (member == null)
            {
                return NotFound();
            }
            else 
            {
                Member = member;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }
            var member = await _context.Member.FindAsync(id);

            if (member != null)
            {
                Member = member;
                _context.Member.Remove(Member);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
