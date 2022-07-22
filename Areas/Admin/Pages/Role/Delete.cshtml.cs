using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unaiit.Models;

namespace Unaiit.Admin.Role
{
    public class DeleteModel : RolePageModel
    {
        public DeleteModel(RoleManager<IdentityRole> roleManager, UnaiitDbContext context) : base(roleManager, context)
        {
        }

        public IdentityRole role { get; set; } = default!;

        public async Task<IActionResult> OnGet(string roleid)
        {
            if (roleid == null)
            {
                return NotFound("Khong tim thay role");
            }
            role = await _roleManager.FindByIdAsync(roleid);
            if (role != null)
            {
                return Page();
            }
            return NotFound("Khong tim thay role");

        }

        public async Task<IActionResult> OnPostAsync(string roleid)
        {
            if (roleid == null)
            {
                return NotFound("Khong co roleid");
            }
            role = await _roleManager.FindByIdAsync(roleid);
            if (role == null)
            {
                return NotFound("Khong tim thay role");
            }

            var res = await _roleManager.DeleteAsync(role);

            if (res.Succeeded)
            {
                StatusMessage = "Xoa role thành công";
                return RedirectToPage("./Index");
            }
            else
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }
        }
    }
}
