using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.Domain.Auth
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
