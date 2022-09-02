using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.Service.Model
{
    public class PostDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Publication_date { get; set; }
    }
}
