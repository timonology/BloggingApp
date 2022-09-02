using BloggingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloggingApp.Persistence.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<OtherBlogPlatform> OtherBlogPlatforms { get; set; }
        Task<int> SaveChangesAsync();
    }
}
