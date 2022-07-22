using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training_Unaiit.Models.Grade;
using Unaiit.Models;

namespace Training_Unaiit.Areas_Grade_Pages
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Unaiit.Models.UnaiitDbContext _context;

        public DeleteModel(Unaiit.Models.UnaiitDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public GradeTable GradeTable { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Grade == null)
            {
                return NotFound();
            }

            var gradetable = await _context.Grade.FirstOrDefaultAsync(m => m.Id.Equals(id));

            if (gradetable == null)
            {
                return NotFound();
            }
            else 
            {
                GradeTable = gradetable;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Grade == null)
            {
                return NotFound();
            }
            var gradetable = await _context.Grade.FindAsync(id);

            if (gradetable != null)
            {
                GradeTable = gradetable;
                _context.Grade.Remove(GradeTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
