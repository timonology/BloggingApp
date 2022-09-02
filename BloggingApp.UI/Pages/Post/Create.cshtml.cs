using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BloggingApp.Domain.Auth;
using BloggingApp.Service.Features.PostFeatures.Commands;
using BloggingApp.Service.Features.PostFeatures.Queries;
using BloggingApp.Service.Interfaces;
using BloggingApp.UI.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BloggingApp.UI.Pages.Post
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IAccountService _accountService;
        [BindProperty]
        public CreatePostCommand createPostModel { get; set; }
        public CreateModel(IMediator mediator, IAccountService accountService)
        {
            _mediator = mediator;
            _accountService = accountService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                ClaimsIdentity identity = (User.Identity as ClaimsIdentity);
                var UserEmailCliams = identity.Claims.Where(x => x.Type == "Email").FirstOrDefault();
                var email = UserEmailCliams.Value;

                var user = await _accountService.GetUserProfile(email);
                createPostModel.UserId = user.Id;
                await _mediator.Send(createPostModel);
            }
            return Page();
        }
    }
}
