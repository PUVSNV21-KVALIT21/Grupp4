﻿using Microsoft.AspNetCore.Identity;

namespace HakimLivsGrupp4.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? BasketId { get; set; }
    }
}
