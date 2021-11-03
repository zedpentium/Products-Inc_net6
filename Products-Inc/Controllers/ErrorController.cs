using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products_Inc.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("/error")]
        public IActionResult Index()
        {
            return new OkObjectResult("wooooo");
        }
    }
}
