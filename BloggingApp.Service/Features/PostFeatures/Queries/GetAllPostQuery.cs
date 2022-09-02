using AutoMapper;
using BloggingApp.Domain.Entities;
using BloggingApp.Persistence.Interfaces;
using BloggingApp.Service.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BloggingApp.Service.Features.PostFeatures.Queries
{
    public class GetAllPostQuery : IRequest<IEnumerable<PostDTO>>
    {
        public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQuery, IEnumerable<PostDTO>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetAllPostQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<PostDTO>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
            {
                var postList = await _context.Posts.ToListAsync();
                if (postList == null) return new List<PostDTO>();

                return _mapper.Map<IEnumerable<PostDTO>>(postList);
            }
        }
    }
}
