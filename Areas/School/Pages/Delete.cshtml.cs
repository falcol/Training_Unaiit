using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training_Unaiit.Models.School;
using Unaiit.Models;

namespace Training_Unaiit.Areas_School
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
      public SchoolTable SchoolTable { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.School == null)
            {
                return NotFound();
            }

            var schooltable = await _context.School.FirstOrDefaultAsync(m => m.Id == id);

            if (schooltable == null)
            {
                return NotFound();
            }
            else 
            {
                SchoolTable = schooltable;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.School == null)
            {
                return NotFound();
            }
            var schooltable = await _context.School.FindAsync(id);

            if (schooltable != null)
            {
                SchoolTable = schooltable;
                _context.School.Remove(SchoolTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
