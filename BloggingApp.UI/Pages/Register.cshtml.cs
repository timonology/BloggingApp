using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingApp.Domain.Auth;
using BloggingApp.Service.Interfaces;
using BloggingApp.UI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BloggingApp.UI.Pages
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly IAccountService _accountService;
        public RegisterModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [BindProperty]
        public UserRegisterModel userRegisterModel { get; set; }
        public string ReturnUrl { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public void OnGet(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                //
                var userRequest = new UserRegistrationRequest()
                {
                    Email = userRegisterModel.Email,
                    FullName = userRegisterModel.FullName,
                    Password = userRegisterModel.Password
                };

                var response = await _accountService.RegisterAsync(userRequest);
                if (!response.IsSuccessful)
                {
                    ModelState.AddModelError(string.Empty, response.Message);
                    return Page();
                }

                return LocalRedirect(returnUrl);
            }

            return Page();
        }


    }
}
