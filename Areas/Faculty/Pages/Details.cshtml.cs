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
    public class DetailsModel : PageModel
    {
        private readonly Unaiit.Models.UnaiitDbContext _context;

        public DetailsModel(Unaiit.Models.UnaiitDbContext context)
        {
            _context = context;
        }

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
    }
}
