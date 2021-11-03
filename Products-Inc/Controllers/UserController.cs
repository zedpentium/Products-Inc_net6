using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products_Inc.Models;
using Products_Inc.Models.Interfaces;
using Products_Inc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Products_Inc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]



    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IShoppingCartService _shoppingCartService;


        public UserController(IUserService userService, IShoppingCartService shoppingCartService)
        {
            this._userService = userService;
            this._shoppingCartService = shoppingCartService;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetAllUsers()
        {
            return new OkObjectResult(_userService.GetAllUsers());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("roles")]
        public ActionResult GetAllRoles()
        {
            return new OkObjectResult(_userService.GetAllRoles());
        }

        //  [Authorize(Roles = "Admin")]
        [HttpGet("roles/{userName}")]
        public async Task<ActionResult> GetAllUserRoles(string userName)
        {
            return new OkObjectResult(new UserViewModel { Roles = await _userService.GetAllUserRoles(userName) });
        }

        private CreateShoppingCartViewModel GetCreateShoppingCartModel(string userId, ShoppingCartViewModel shoppingCart)
        {
            CreateShoppingCartViewModel createShoppingCart = new CreateShoppingCartViewModel();
            shoppingCart.Products.ForEach(p => createShoppingCart.AddProduct(p));
            createShoppingCart.UserId = userId;
            return createShoppingCart;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = await _userService.Login(loginModel);
                
                if(this.Request.Cookies["shopping-cart"] != null && !string.IsNullOrEmpty(this.Request.Cookies["shopping-cart"]))
                {
                    CreateShoppingCartViewModel shoppingCart = GetCreateShoppingCartModel(user.Id, JsonConvert.DeserializeObject<ShoppingCartViewModel>(this.Request.Cookies["shopping-cart"]));
                    this.Response.Cookies.Append("shopping-cart", JsonConvert.SerializeObject(_shoppingCartService.Create(shoppingCart)));
                }

                return new OkObjectResult(user);
            }
            else
            {
                return new BadRequestObjectResult(new { errorMsg = "Incorrect model" });
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserViewModel userModel = await _userService.Add(registerModel);
                    return new CreatedResult("api/user/register", userModel);

                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(new { errorMsg = e.Message });
                }
            }
            else
            {
                return new BadRequestObjectResult(new { errorMsg = "Incorrect model" });
            }
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            _userService.Logout();

            if (returnUrl != null)
            {
                return new OkObjectResult(new { msg = "Logged Out. Can redirect to page is needed" });
            }
            else
            {
                return new OkObjectResult(new { msg = "Logged Out" });
            }
        }

        [HttpPut("{userName}")]
        public async Task<IActionResult> EditUser(string userName, [FromBody] UpdateUserViewModel updateModel)
        {
            bool login = User.Identity.Name.Equals(userName);

            UserViewModel user = await _userService.Update(updateModel.UserId, updateModel, login);


            return new OkObjectResult(user);
        }


        [Authorize(Roles = "User")]
        [HttpGet("me")]
        public async Task<IActionResult> GetLoggedInUserInfo()
        {
            if (User.Identity.IsAuthenticated)
            {
                UserViewModel user = await _userService.FindBy(User.Identity.Name);
                return new OkObjectResult(user);
            }
            else
            {
                return new UnauthorizedResult();
            }
        }

        //[HttpPut("/{id}/roles/{role}")]
        //public async Task<IActionResult> AddRoleToUser(string id, string role)
        //{
        //    await _userService.AddRole(id, role);
        //    return new OkObjectResult("ok");

        //}

        [HttpPut("roles/{userName}")]
        public async Task<IActionResult> AddRoleToUser(string userName, [FromBody] List<string> roles)
        {
            UserViewModel user = await _userService.ReplaceRoles(userName, roles);
            return new OkObjectResult(user);
        }


        [HttpGet("accessdenied")]
        public IActionResult AccessDenied()
        {
            return new BadRequestObjectResult(new { errorMsg = "Access Denied." });
        }
    }
}


/*
 
 
  [HttpPOST]
C - Create new user 
return view with the created product


R -  GET user info


U - get 1 user to view and edit. 
When pressing save /submit button goto PUT/PAtch.

 
U - PUT/Patch
Edit user find by ID
return partial view, viewmodel 



D - 






 
 
 
 
 
 
 
 
 
 
 */