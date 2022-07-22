using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Training_Unaiit.Models.Faculty;
using Unaiit.Models;

namespace Training_Unaiit.Areas_Faculty_Pages
{
    public class EditModel : PageModel
    {
        private readonly Unaiit.Models.UnaiitDbContext _context;

        public EditModel(Unaiit.Models.UnaiitDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FacultyTable FacultyTable { get; set; } = default!;

        public SelectList? allSchool { get; set; }

        [BindProperty]
        [Display(Name = "Schools")]
        public string[]? SchoolId { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Faculty == null)
            {
                return NotFound();
            }
            allSchool = new SelectList(await _context.School.ToListAsync(), "Id", "Name");


            var facultytable =  await _context.Faculty.FirstOrDefaultAsync(m => m.Id == id);
            if (facultytable == null)
            {
                return NotFound();
            }
            FacultyTable = facultytable;
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
            FacultyTable.SchoolId = Guid.Parse(SchoolId[0]);

            _context.Attach(FacultyTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultyTableExists(FacultyTable.Id))
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

        private bool FacultyTableExists(Guid id)
        {
          return (_context.Faculty?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
