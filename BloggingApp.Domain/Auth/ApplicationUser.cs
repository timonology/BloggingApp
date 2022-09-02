﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.Domain.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
