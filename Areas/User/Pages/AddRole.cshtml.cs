// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Unaiit.Models;

namespace Training_Unaiit.Areas.User
{
    public class AddRoleModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;
        public AddRoleModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>

        public AppUser user { get; set; }

        public SelectList allRoles { get; set; }

        [BindProperty]
        [Display(Name = "Role")]
        public string[] RoleNames { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("Khong co user");
            }
            user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{id}'.");
            }

            RoleNames = (await _userManager.GetRolesAsync(user)).ToArray<string>();

            List<string> roles = _roleManager.Roles.Select(x => x.Name).ToList();
            allRoles = new SelectList(roles);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (string.IsNullOrEmpty(id))
            {
                return NotFound("Khong co user");
            }
            user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{id}'.");
            }

            var OldRoleName = (await _userManager.GetRolesAsync(user)).ToArray();
            var deleteRoles = OldRoleName.Where(x => !RoleNames.Contains(x));
            var addRoles = RoleNames.Where(x => !OldRoleName.Contains(x));

            var resultDelete = await _userManager.RemoveFromRolesAsync(user, deleteRoles);

            if (!resultDelete.Succeeded)
            {
                foreach (var error in resultDelete.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                List<string> roles = _roleManager.Roles.Select(x => x.Name).ToList();
                allRoles = new SelectList(roles);
                return Page();
            }

            var resultAdd = await _userManager.AddToRolesAsync(user, addRoles);
            if (!resultAdd.Succeeded)
            {
                foreach (var error in resultAdd.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                List<string> roles = _roleManager.Roles.Select(x => x.Name).ToList();
                allRoles = new SelectList(roles);
                return Page();
            }

            StatusMessage = "Cập nhật thành công";

            return RedirectToPage("./Index");
        }
    }
}
