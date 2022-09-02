using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BloggingApp.Domain.Auth;
using BloggingApp.Service.Interfaces;
using BloggingApp.UI.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BloggingApp.UI.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;
        public LoginModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [BindProperty]
        public UserLoginModel userLoginModel { get; set; }
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
                var loginRequest = new AuthenticationRequest()
                {
                    Email = userLoginModel.Email,
                    Password = userLoginModel.Password
                };
                var user = await _accountService.AuthenticationAsync(loginRequest);
                if (!user.IsSuccessful)
                {
                    ModelState.AddModelError(string.Empty, user.Message);
                    return Page();
                }

                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                identity.AddClaim(new Claim("Email", user.Email ?? ""));
                identity.AddClaim(new Claim("Role", user.Roles.ToString() ?? ""));
                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                                    new ClaimsPrincipal(identity));

                return LocalRedirect(returnUrl);
            }
            return Page();
        }
    }
}
