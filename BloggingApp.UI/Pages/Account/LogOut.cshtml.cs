using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingApp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BloggingApp.UI.Pages.Account
{
    public class LogOutModel : PageModel
    {
        private readonly IAccountService _accountService;
        public LogOutModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _accountService.LogOut();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }


    }
}
