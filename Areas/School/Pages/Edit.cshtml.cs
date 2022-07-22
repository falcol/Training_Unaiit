using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Training_Unaiit.Models.School;
using Unaiit.Models;

namespace Training_Unaiit.Areas_School
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Unaiit.Models.UnaiitDbContext _context;

        public EditModel(Unaiit.Models.UnaiitDbContext context)
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

            var schooltable =  await _context.School.FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (schooltable == null)
            {
                return NotFound();
            }
            SchoolTable = schooltable;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SchoolTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolTableExists(SchoolTable.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SchoolTableExists(Guid id)
        {
          return (_context.School?.Any(e => e.Id.Equals(id))).GetValueOrDefault();
        }
    }
}
