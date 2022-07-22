using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training_Unaiit.Models.Grade;
using Unaiit.Models;

namespace Training_Unaiit.Areas_Grade_Pages
{
    public class IndexModel : PageModel
    {
        private readonly Unaiit.Models.UnaiitDbContext _context;

        public IndexModel(Unaiit.Models.UnaiitDbContext context)
        {
            _context = context;
        }

        public IList<GradeTable> GradeTable { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Grade != null)
            {
                GradeTable = await _context.Grade.ToListAsync();
            }
        }
    }
}
