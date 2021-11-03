using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Products_Inc.Models.ViewModels;

namespace Products_Inc.Models.Interfaces
{
    public interface IUserService
    {
       Task<UserViewModel> Add(RegisterModel registerModel);

     

        Task<UserViewModel> FindBy(string userName);

        bool Remove(int id);

        Task<bool> AddRole(string userName, string role);
        Task<UserViewModel> Login(LoginModel loginModel);

        void Logout();
        Task<UserViewModel> Update(string userId, UpdateUserViewModel updateModel, bool login);
        List<UserViewModel> GetAllUsers();
        List<string> GetAllRoles();
        Task<UserViewModel> ReplaceRoles(string userName, List<string> roles);
        Task<List<string>> GetAllUserRoles(string userName);
    }
}
