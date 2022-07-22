using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Unaiit.Models;

namespace Unaiit.Admin.Role
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : RolePageModel
    {
        public IndexModel(RoleManager<IdentityRole> roleManager, UnaiitDbContext context) : base(roleManager, context)
        {
        }

        public List<IdentityRole> roles { get; set; } = default!;

        public async Task OnGet()
        {
            roles = await _roleManager.Roles.ToListAsync();
        }

        public void OnPost() => RedirectToPage();
    }
}
