using System.ComponentModel.DataAnnotations;
 
namespace Products_Inc.Models.ViewModels
{
    public class IdentityRoleModification
    {
        [Required]
        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string[] AddIds { get; set; }

        public string[] DeleteIds { get; set; }
    }
}