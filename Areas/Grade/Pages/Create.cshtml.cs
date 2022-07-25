using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Training_Unaiit.Models.Grade;
using Unaiit.Models;

namespace Training_Unaiit.Areas_Grade_Pages
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Unaiit.Models.UnaiitDbContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(Unaiit.Models.UnaiitDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public SelectList? allGrades { get; set; }

        [BindProperty]
        [Display(Name = "Khoa")]
        [Required(ErrorMessage = "Vui lòng chọn khối")]
        public string[]? GradelId { get; set; }

        public async Task<IActionResult> OnGet()
        {
            allGrades = new SelectList(await _context.Faculty.ToListAsync(), "Id", "Name");

            return Page();
        }

        [BindProperty]
        public GradeTable GradeTable { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Grade == null || GradeTable == null)
            {
                allGrades = new SelectList(await _context.Faculty.ToListAsync(), "Id", "Name");

                return Page();
            }
            // GradeTable.FacultyId = Guid.Parse(GradelId[0]);
            GradeTable.Id = Guid.NewGuid();

            _context.Grade.Add(GradeTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
