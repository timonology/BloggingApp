using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BloggingApp.Service.Features.PostFeatures.Queries;
using BloggingApp.Service.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BloggingApp.UI.Pages.Post
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private IMediator _mediator;
        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [BindProperty]
        public IEnumerable<PostDTO> allPostQueries { get; set; }
        public string sortDate { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            ClaimsIdentity identity = (User.Identity as ClaimsIdentity);
            var UserIdCliams = identity.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            var userId = UserIdCliams.Value;

            if (!string.IsNullOrEmpty(sortOrder))
                allPostQueries = await _mediator.Send(new SortAllPostByPublicationDateQuery());
            else
                allPostQueries = await _mediator.Send(new GetPostByUserIdQuery() { UserId = userId });
        }
    }
}
