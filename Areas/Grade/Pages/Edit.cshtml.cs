using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Training_Unaiit.Models.Grade;
using Unaiit.Models;

namespace Training_Unaiit.Areas_Grade_Pages
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
        public GradeTable GradeTable { get; set; } = default!;

        public SelectList? allFal { get; set; }

        [BindProperty]
        [Display(Name = "Grade")]
        [Required(ErrorMessage = "Vui lòng chọn khối")]
        public string[]? FacultyId { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Grade == null)
            {
                return NotFound();
            }

            allFal = new SelectList(await _context.Faculty.ToListAsync(), "Id", "Name");

            var gradetable =  await _context.Grade.FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (gradetable == null)
            {
                return NotFound();
            }
            GradeTable = gradetable;
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

            GradeTable.FacultyId = Guid.Parse(FacultyId[0]);
            _context.Attach(GradeTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeTableExists(GradeTable.Id))
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

        private bool GradeTableExists(Guid id)
        {
          return (_context.Grade?.Any(e => e.Id.Equals(id))).GetValueOrDefault();
        }
    }
}
