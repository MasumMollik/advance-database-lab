using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PerformanceCalculator.Pages.Account
{
    public class loginModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private bool isPersistent;
        public loginModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            /*[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]*/
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
            public bool RememberMe { get; set; }
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var u          = await userManager.FindByEmailAsync(Input.Email);


                var result = await signInManager.PasswordSignInAsync(u.UserName, Input.Password, Input.RememberMe,false); ;
                if (result.Succeeded)
                {
                    return RedirectToPage("../index");
                }
                else
                {
                    return RedirectToPage("/Account/login");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return RedirectToPage("/Account/login");
        }
    }
}
