using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.Domain.Auth
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
