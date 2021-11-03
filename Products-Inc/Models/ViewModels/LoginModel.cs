using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Products_Inc.Models.ViewModels
{
    public class LoginModel
    {

        
        [Required]
        [JsonProperty(PropertyName = "PropertyName")]
        public string UserName { get; set; }
        [Required]
        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "RememberMe")]
        public bool RememberMe { get; set; }

        public LoginModel()
        {

        }
    }
}
