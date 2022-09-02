using AutoMapper;
using BloggingApp.Persistence.Interfaces;
using BloggingApp.Service.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BloggingApp.Service.Features.PostFeatures.Queries
{
    public class GetPostByUserIdQuery : IRequest<IEnumerable<PostDTO>>
    {
        public string UserId { get; set; }

        public class GetPostByUserIdQueryHandler : IRequestHandler<GetPostByUserIdQuery, IEnumerable<PostDTO>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetPostByUserIdQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<IEnumerable<PostDTO>> Handle(GetPostByUserIdQuery request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.Where(x => x.UserId == request.UserId).ToListAsync();
                if (post == null) return null;
                return _mapper.Map<IEnumerable<PostDTO>>(post);
            }
        }
    }
}
