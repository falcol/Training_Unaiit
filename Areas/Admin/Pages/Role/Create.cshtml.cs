using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unaiit.Models;

namespace Unaiit.Admin.Role
{
    public class CreateModel : RolePageModel
    {
        public CreateModel(RoleManager<IdentityRole> roleManager, UnaiitDbContext context) : base(roleManager, context)
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

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var NewRole = new IdentityRole(Input.Name);
            var res = await _roleManager.CreateAsync(NewRole);
            if (res.Succeeded)
            {
                StatusMessage = "Tạo role thành công";
                return RedirectToPage();
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
