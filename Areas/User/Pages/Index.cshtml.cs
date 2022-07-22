using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Unaiit.Models;

namespace Unaiit.Admin.User
{
    public class IndexModel : PageModel
    {

        private readonly UserManager<AppUser> _userManager;
        public IndexModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public class UserAndRole : AppUser
        {
            public string RoleNames { get; set; }
        }

        public List<UserAndRole> users { get; set; } = default!;

        public List<IdentityRole> roles { get; set; } = default!;


        [TempData]
        public string StatusMessage { get; set; } = default!;

        public int CountPages { get; set; } = default!;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int CurrentPage { get; set; } = default!;
        public const int ITEMS_PER_PAGE = 10;

        public int totalUsers { get; set; }

        public async Task OnGet()
        {
            // users = await _userManager.Users.OrderBy(u => u.UserName).ToListAsync();
            var qr = _userManager.Users.OrderBy(u => u.UserName);

            totalUsers = qr.Count();
            CountPages = (int)Math.Ceiling((double)totalUsers / ITEMS_PER_PAGE);
            if (CurrentPage < 1)
            {
                CurrentPage = 1;
            }
            else if (CurrentPage > CountPages)
            {
                CurrentPage = CountPages;
            }

            var users1 = qr.Skip((CurrentPage - 1) * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE).Select(u => new UserAndRole
            {
                Id = u.Id,
                UserName = u.UserName,
            });
            users = await users1.ToListAsync();

            foreach (var user in users)
            {
                var roles = (await _userManager.GetRolesAsync(user)).ToArray<string>();
                user.RoleNames = string.Join(", ", roles);
            }

        }

        public void OnPost() => RedirectToPage();
    }
}
