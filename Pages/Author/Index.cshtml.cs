using System;
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
    public class IndexModel : PageModel
    {
        private readonly Blegu_Larisa_lab2.Data.Blegu_Larisa_lab2Context _context;

        public IndexModel(Blegu_Larisa_lab2.Data.Blegu_Larisa_lab2Context context)
        {
            _context = context;
        }

        public IList<Blegu_Larisa_lab2.Models.Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Author != null)
            {
                Author = await _context.Author.ToListAsync();
            }
        }
    }
}
