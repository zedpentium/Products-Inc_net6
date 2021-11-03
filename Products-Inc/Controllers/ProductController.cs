using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Products_Inc.Models.Interfaces;
using Products_Inc.Models.ViewModels;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Products_Inc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;

        public ProductController(IImageService imageService, IProductService iProductService)
        {
            _imageService = imageService;
            _productService = iProductService;

        }


        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public IActionResult AllProducts()
        {
            return new OkObjectResult(_productService.ReadAll());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
           return new OkObjectResult(_productService.FindBy(id));
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductViewModel createProductViewModel)
        {
            if (ModelState.IsValid)
                {
                    ProductViewModel createdProduct = _productService.Create(createProductViewModel);

                    return new OkObjectResult(createdProduct);

            }
            else
            {
                return new BadRequestObjectResult(new { msg = "Invalid body" });
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{productId}")]
        public IActionResult DeleteProduct(int productId, [FromBody] CreateProductViewModel product)
        {
           
           ProductViewModel editedProduct = _productService.Update(productId, product);

            return new OkObjectResult(editedProduct);


        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            bool success = _productService.Delete(id);

            if (success)
            {
                return new OkResult();
            }
            else
            {
                return new BadRequestObjectResult(new { msg = "Product not managed to be deleted. " });
            }

        }

    }


}