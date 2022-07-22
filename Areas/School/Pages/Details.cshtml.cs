using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training_Unaiit.Models.School;
using Unaiit.Models;

namespace Training_Unaiit.Areas_School
{
    public class DetailsModel : PageModel
    {
        private readonly Unaiit.Models.UnaiitDbContext _context;

        public DetailsModel(Unaiit.Models.UnaiitDbContext context)
        {
            _context = context;
        }

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
    }
}
