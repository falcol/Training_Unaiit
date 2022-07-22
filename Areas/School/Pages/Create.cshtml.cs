using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Training_Unaiit.Models.School;
using Unaiit.Models;

namespace Training_Unaiit.Areas_School
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
        public SchoolTable SchoolTable { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.School == null || SchoolTable == null)
            {
                return Page();
            }

            SchoolTable.Id = Guid.NewGuid();
            _context.School.Add(SchoolTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
