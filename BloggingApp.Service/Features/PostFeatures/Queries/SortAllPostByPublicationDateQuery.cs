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
    public class SortAllPostByPublicationDateQuery : IRequest<IEnumerable<PostDTO>>
    {
        public class SortAllPostByPublicationDateQueryHandler : IRequestHandler<SortAllPostByPublicationDateQuery, IEnumerable<PostDTO>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public SortAllPostByPublicationDateQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<PostDTO>> Handle(SortAllPostByPublicationDateQuery request, CancellationToken cancellationToken)
            {
                var sortPost = await _context.Posts.OrderByDescending(x => x.publication_date).ToListAsync();
                if (sortPost == null) return new List<PostDTO>();
                return _mapper.Map<IEnumerable<PostDTO>>(sortPost);
            }
        }
    }
}
