using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Training_Unaiit.Models.Faculty;
using Training_Unaiit.Models.School;
using Unaiit.Models;

namespace Training_Unaiit.Areas_Faculty_Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly Unaiit.Models.UnaiitDbContext _context;

        public CreateModel(Unaiit.Models.UnaiitDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public SelectList? allSchool { get; set; }

        [BindProperty]
        [Display(Name = "Schools")]
        [Required(ErrorMessage = "Bạn chưa chọn trường")]
        public string[]? SchoolId { get; set; }

        public async Task<IActionResult> OnGet()
        {
            allSchool = new SelectList(await _context.School.ToListAsync(), "Id", "Name");

            return Page();
        }

        [BindProperty]
        public FacultyTable FacultyTable { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // FacultyTable.SchoolId = Guid.Parse(SchoolId[0]);
            if (!ModelState.IsValid || _context.Faculty == null || FacultyTable == null)
            {
                _logger.LogInformation("ModelState is valid {}", ModelState.IsValid);
                _logger.LogInformation("HELLO FAIL");
                allSchool = new SelectList(await _context.School.ToListAsync(), "Id", "Name");
                return Page();
            }
            FacultyTable.Id = Guid.NewGuid();
            // _logger.LogInformation("FACULTY TABLE {} ", FacultyTable.ToJson());

            _context.Faculty.Add(FacultyTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
