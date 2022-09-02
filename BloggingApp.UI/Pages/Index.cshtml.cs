using BloggingApp.Domain.Common;
using BloggingApp.Service.Features.PostFeatures.Queries;
using BloggingApp.Service.Interfaces;
using BloggingApp.Service.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingApp.UI.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(IMediator mediator, ILogger<IndexModel> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [BindProperty]
        public IEnumerable<PostDTO> allPostQueries { get; set; }
        public Response<List<object>> otherPost { get; set; }
        public string sortDate { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            _logger.LogInformation("Testing Log functionality");
            if (!string.IsNullOrEmpty(sortOrder))
                allPostQueries = await _mediator.Send(new SortAllPostByPublicationDateQuery());
            else
                allPostQueries = await _mediator.Send(new GetAllPostQuery());
        }
    }
}
