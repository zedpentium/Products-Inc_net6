using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Products_Inc.Models.Interfaces;
using Products_Inc.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products_Inc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _service;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public ShoppingCartController(IProductService _productService, IShoppingCartService service, IUserService userService)
        {
            _service = service;
            _userService = userService;
            this._productService = _productService;
        }


        [Authorize(Roles = "User")]
        [HttpPost("buy")]
        public async Task<IActionResult> GetOrder(ShoppingCartViewModel shoppingCart)
        {
            if (string.IsNullOrEmpty(shoppingCart.ShoppingCartId))
            {
                shoppingCart = _service.Create(await GetCreateShoppingCartModel(shoppingCart));
            }
            if (string.IsNullOrEmpty(shoppingCart.UserId))
            {

            }

            OrderViewModel order = _service.CreateOrder(shoppingCart);

            if (this.Request.Cookies["shopping-cart"] != null)
            {
                this.Response.Cookies.Delete("shopping-cart");
            }

            return new OkObjectResult(order);
        }

        [HttpGet("users")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetShoppingCart()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var user = await _userService.FindBy(this.User.Identity.Name);
                ShoppingCartViewModel shoppingCart = _service.FindActiveBy(user.Id);
                this.Response.Cookies.Append("shopping-cart", JsonConvert.SerializeObject(shoppingCart));
                return new OkObjectResult(shoppingCart);
            }
            else
            {
                return new UnauthorizedResult();
            }
        }

        private ShoppingCartViewModel TryGetCookie()
        {
            try
            {
                return JsonConvert.DeserializeObject<ShoppingCartViewModel>(this.Request.Cookies["shopping-cart"], new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            catch (JsonException)
            {
                return new ShoppingCartViewModel() { Products = new List<ShoppingCartProductViewModel>() };
            }
        }

        private void TryAppendCookie(ShoppingCartViewModel shoppingCart)
        {
            this.Response.Cookies.Append("shopping-cart", JsonConvert.SerializeObject(shoppingCart));
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> PostShoppingCart([FromBody] ShoppingCartViewModel shoppingCartViewModel)
        {
            if (ModelState.IsValid)
            {
                ShoppingCartViewModel shoppingCart = _service.Create(await GetCreateShoppingCartModel(shoppingCartViewModel));
                TryAppendCookie(shoppingCart);

                return new CreatedAtRouteResult("/api/shoppingcart", shoppingCart);

            }

            return new BadRequestObjectResult(new { msg = "Invalid body." });
        }

        private async Task<CreateShoppingCartViewModel> GetCreateShoppingCartModel(ShoppingCartProductViewModel product)
        {
            CreateShoppingCartViewModel createShoppingCart = new CreateShoppingCartViewModel();
            createShoppingCart.AddProduct(product);
            UserViewModel user = await _userService.FindBy(User.Identity.Name);
            createShoppingCart.UserId = user.Id;
            return createShoppingCart;
        }

        private async Task<CreateShoppingCartViewModel> GetCreateShoppingCartModel(ShoppingCartViewModel shoppingCart)
        {
            CreateShoppingCartViewModel createShoppingCart = new CreateShoppingCartViewModel();
            shoppingCart.Products.ForEach(p => createShoppingCart.AddProduct(p));
            UserViewModel user = await _userService.FindBy(User.Identity.Name);
            createShoppingCart.UserId = user.Id;
            return createShoppingCart;
        }

        private async Task<CreateShoppingCartViewModel> GetCreateShoppingCartModel(ShoppingCartViewModel cart, ShoppingCartProductViewModel product)
        {
            CreateShoppingCartViewModel createShoppingCart = new CreateShoppingCartViewModel();
            bool addProduct = true;

            foreach (ShoppingCartProductViewModel pr in cart.Products)
            {
                if (pr.ProductId == product.ProductId)
                {
                    pr.Amount += product.Amount;
                    createShoppingCart.AddProduct(pr);
                    addProduct = false;
                }
            }

            if (addProduct)
                createShoppingCart.AddProduct(product);

            UserViewModel user = await _userService.FindBy(User.Identity.Name);
            createShoppingCart.UserId = user.Id;
            return createShoppingCart;
        }

        [HttpPut("products")]
        public IActionResult UpdateProduct([FromBody] ShoppingCartProductViewModel product)
        {

            if (this.Request.Cookies["shopping-cart"] == null || string.IsNullOrEmpty(this.Request.Cookies["shopping-cart"]))
            {
                return new BadRequestResult();
            }
            else
            {
                ShoppingCartViewModel shoppingCart = JsonConvert.DeserializeObject<ShoppingCartViewModel>(this.Request.Cookies["shopping-cart"], new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                if (this.User.Identity.IsAuthenticated)
                {
                   shoppingCart = _service.UpdateProduct(product, shoppingCart);
                }
                else
                {

                    if(product.Amount == 0)
                    {
                        shoppingCart.RemoveProduct(product);
                    }
                    else
                    {
                        ShoppingCartProductViewModel scp = shoppingCart.Products.First(p => p.ProductId == product.ProductId);
                        if(scp != null)
                        {
                            scp.Amount = product.Amount;
                        }
                    }

                }

                TryAppendCookie(shoppingCart);
                return new OkObjectResult(shoppingCart);
            }


        }

        [HttpPost("products")]
        public async Task<IActionResult> AddProduct(ShoppingCartProductViewModel product)
        {

            ShoppingCartViewModel shoppingCart;

            if (ModelState.IsValid)
            {

                if (this.Request.Cookies["shopping-cart"] == null || string.IsNullOrEmpty(this.Request.Cookies["shopping-cart"]))
                {

                    if (User.Identity.IsAuthenticated)
                    {

                        shoppingCart = _service.Create(await GetCreateShoppingCartModel(product));
                    }
                    else
                    {
                        _productService.FindBy(product.ProductId);
                        shoppingCart = new ShoppingCartViewModel() { Products = new List<ShoppingCartProductViewModel>() { product } };
                    }

                    TryAppendCookie(shoppingCart);
                }
                else
                {
                    shoppingCart = JsonConvert.DeserializeObject<ShoppingCartViewModel>(this.Request.Cookies["shopping-cart"], new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    if (this.User.Identity.IsAuthenticated)
                    {
                        if (string.IsNullOrEmpty(shoppingCart.ShoppingCartId))
                        {
                            CreateShoppingCartViewModel createShoppingCart = await GetCreateShoppingCartModel(product);
                           
                            shoppingCart = _service.Create(createShoppingCart);
                        }
                        else
                        {
                            shoppingCart = _service.AddProduct(product.ProductId, shoppingCart.ShoppingCartId, product.Amount);
                        }

                    }
                    else
                    {
                        _productService.FindBy(product.ProductId);

                        bool addProd = true;
                        foreach (ShoppingCartProductViewModel pr in shoppingCart.Products)
                        {
                            if (pr.ProductId == product.ProductId)
                            {
                                pr.Amount += product.Amount;
                                addProd = false;
                            }
                        }

                        if(addProd)
                            shoppingCart.AddProduct(product);
                    }

                    TryAppendCookie(shoppingCart);
                }


                return new OkObjectResult(shoppingCart);
            }
            return new BadRequestObjectResult(new { msg = "Invalid body, product-id missing." });
        }


    }
}
