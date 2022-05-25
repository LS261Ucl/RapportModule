﻿using Microsoft.AspNetCore.Identity;

namespace Rapport.Entites.Identity
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
