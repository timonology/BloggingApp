using BloggingApp.Domain.Entities;
using BloggingApp.Persistence.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BloggingApp.Service.Features.PostFeatures.Commands
{
    public class CreatePostCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Publication_date { get; set; }
        public string UserId { get; set; }
        public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
        {
            public readonly IApplicationDbContext _context;
            public CreatePostCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
            {
                var post = new Post()
                {
                    title = request.Title,
                    description = request.Description,
                    publication_date = request.Publication_date,
                    UserId = request.UserId
                };

                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
                return post.Id;
            }
        }
    }
}
