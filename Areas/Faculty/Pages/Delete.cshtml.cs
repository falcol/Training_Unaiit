using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training_Unaiit.Models.Faculty;
using Unaiit.Models;

namespace Training_Unaiit.Areas_Faculty_Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Unaiit.Models.UnaiitDbContext _context;

        public DeleteModel(Unaiit.Models.UnaiitDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public FacultyTable FacultyTable { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Faculty == null)
            {
                return NotFound();
            }

            var facultytable = await _context.Faculty.FirstOrDefaultAsync(m => m.Id == id);

            if (facultytable == null)
            {
                return NotFound();
            }
            else 
            {
                FacultyTable = facultytable;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Faculty == null)
            {
                return NotFound();
            }
            var facultytable = await _context.Faculty.FindAsync(id);

            if (facultytable != null)
            {
                var grade = await _context.Grade.Where(x => x.FacultyId == id).ToListAsync();
                foreach (var item in grade)
                {
                    _context.Grade.Remove(item);
                }
                FacultyTable = facultytable;
                _context.Faculty.Remove(FacultyTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
