using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unaiit.Models;
// using Microsoft.AspNetCore.RazorPages;

namespace Unaiit.Admin.Role
{
    public class RolePageModel : PageModel
    {
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly UnaiitDbContext _context;

        [TempData]
        public string? StatusMessage { get; set; } = default!;
        public RolePageModel(RoleManager<IdentityRole> roleManager, UnaiitDbContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }
    }
}
