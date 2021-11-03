using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Products_Inc.Models
{
    public class User : IdentityUser
    {
        public User() { }

        public User(string userId, string userName) {
            Id = userId;
            UserName = userName;
        }

        //public string Id { get; set; } // Added column with UserId as Int to link tables

        public List<Order> Orders { get; set; }

        //public override string Id { get; set; } // default Primary key of identity
        //public override string UserName { get; set; } //default identity

        //public string Email { get; set; } // default



        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string BirthDate { get; set; }




    }
}