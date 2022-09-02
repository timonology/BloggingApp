using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.Domain.Auth
{
    public class UserRegistrationResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
