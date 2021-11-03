using System.Collections.Generic;

namespace Products_Inc.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; internal set; }
        public string UserName { get; internal set; }

        public List<string> Roles { get; set; }

        public bool FoundUser { get; set; }
    }
}