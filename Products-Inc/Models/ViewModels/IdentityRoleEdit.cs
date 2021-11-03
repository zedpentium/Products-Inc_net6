using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Products_Inc.Models.ViewModels
{
    public class IdentityRoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
}