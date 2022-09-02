using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.Domain.Auth
{
    public class UserRegistrationRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
