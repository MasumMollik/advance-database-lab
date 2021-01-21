using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PerformanceCalculator.Models.Auth;

namespace PerformanceCalculator.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public Register Register { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userName = Register.Email.ToLower().Split("@");

            var user = new IdentityUser {UserName = $"{userName[0]}", Email = Register.Email};
            var result = await _userManager.CreateAsync(user, Register.Password);
            if (result.Succeeded)
            {
                return RedirectToPage("./Login");
            }

            return Page();
        }
    }
}