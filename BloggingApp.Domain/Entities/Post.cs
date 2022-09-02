using BloggingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string title { get; set; }
        public string description { get; set; }
        public DateTime publication_date { get; set; }
        public string UserId { get; set; }
    }
}
