using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Training_Unaiit.Models.Grade;
using Unaiit.Models;

namespace Training_Unaiit.Areas_Grade_Pages
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Unaiit.Models.UnaiitDbContext _context;

        public CreateModel(Unaiit.Models.UnaiitDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GradeTable GradeTable { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Grade == null || GradeTable == null)
            {
                return Page();
            }

            _context.Grade.Add(GradeTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
