using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Products_Inc.Models;
using Products_Inc.Models.ViewModels;
using Products_Inc.Models.Interfaces;
using Products_Inc.Models.Services;
using Microsoft.AspNetCore.Authorization;

namespace Products_Inc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrderController(IOrderService iOrderService, IUserService userService)
        {
            _orderService = iOrderService;
            _userService = userService;

        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderViewModel createOrderViewModel)
        {
            if (ModelState.IsValid)
            {
                return new OkObjectResult(_orderService.Create(createOrderViewModel));

            }
            return new BadRequestObjectResult(new { msg = "Invalid body" });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return new OkObjectResult(_orderService.ReadAll());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("users/{userid}")]
        public IActionResult GetUserOrders(string userid)
        {
            return new OkObjectResult(_orderService.FindAllBy(userid));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("products/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            _orderService.DeleteProduct(productId);

            return new OkResult();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("products/{productId}")]
        public IActionResult UpdateProduct(int productId, OrderProductViewModel orderProduct)
        {
           OrderProductViewModel newOrderProduct = _orderService.UpdateProduct(productId, orderProduct);
           return new OkObjectResult(newOrderProduct);
        }

        [Authorize(Roles = "User")]
        [HttpGet("users")]
        public async Task<IActionResult> GetLoggedInUserOrders()
        {
            if (User.Identity.IsAuthenticated)
            {
                UserViewModel user = await _userService.FindBy(User.Identity.Name);
                return new OkObjectResult(_orderService.FindAllBy(user.Id));

            }
            else
            {
                return new UnauthorizedResult();
            }
        }



    }
}


