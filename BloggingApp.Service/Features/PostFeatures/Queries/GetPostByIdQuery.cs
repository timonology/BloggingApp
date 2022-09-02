using AutoMapper;
using BloggingApp.Domain.Entities;
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
    public class GetPostByIdQuery : IRequest<PostDTO>
    {
        public int Id { get; set; }
        public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostDTO>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetPostByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<PostDTO> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (post == null) return null;
                return _mapper.Map<PostDTO>(post);
            }
        }
    }
}
