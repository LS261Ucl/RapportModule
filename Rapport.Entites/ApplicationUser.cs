﻿using Microsoft.AspNetCore.Identity;

namespace Rapport.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
