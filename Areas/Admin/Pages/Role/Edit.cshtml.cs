using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unaiit.Models;

namespace Unaiit.Admin.Role
{
    public class EditModel : RolePageModel
    {
        public EditModel(RoleManager<IdentityRole> roleManager, UnaiitDbContext context) : base(roleManager, context)
        {
        }

        public class InputModel
        {
            [Display(Name = "Tên role")]
            [Required(ErrorMessage = "Cần phải có tên role")]
            [StringLength(256, ErrorMessage = "Tên role không được vượt quá 256 ký tự")]
            public string Name { get; set; } = default!;
        }

        [BindProperty]
        public InputModel Input { get; set; } = default!;

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
                Input = new InputModel()
                {
                    Name = role.Name
                };
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            role.Name = Input.Name;
            var res = await _roleManager.UpdateAsync(role);

            if (res.Succeeded)
            {
                StatusMessage = "Update role thành công";
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
