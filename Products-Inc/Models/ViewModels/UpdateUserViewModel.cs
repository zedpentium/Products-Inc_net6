using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products_Inc.Models.ViewModels
{
    public class UpdateUserViewModel
    {


        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public List<string> Roles { get; set; }

        public string UserId { get; set; }

        public UpdateUserViewModel()
        {

        }


    }
}
