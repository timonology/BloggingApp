using BloggingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.Domain.Entities
{
    public class OtherBlogPlatform : BaseEntity
    {
        public string Endpoint { get; set; }
        public bool HasAuthentication { get; set; }
    }
}
