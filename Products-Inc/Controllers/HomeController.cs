using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products_Inc.Models;
using Products_Inc.Models.ViewModels;
using Products_Inc.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Products_Inc.Controllers
{
    //[Authorize]//(Roles = "RegisteredUser, User, Admin")]

    public class HomeController : Controller
    {
        //All new PeopleService() is now replaced by DI via this Constructor, and using _peopleService instead /ER
        //private readonly IProductService _productService;
        //private readonly IOrderService _orderService;

        //public ReactController(IProductService productService, IOrderService orderService)
        //{
        //    _productService = productService;
        //    _orderService = orderService;
        //}


        [HttpGet]
        public IActionResult Index()
        {

            return View("Index");
        }


        //public JsonResult GetProducts()
        //{
        //    return Json(new { result = "This is info from controller" }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        //}


        //[HttpGet]
        //public IActionResult AllPeopleList()
        //{
        //    /*PeopleViewModel peopleViewModel = new PeopleViewModel()
        //    {
        //        PeopleListView = _peopleService.All().PeopleListView,
        //        CityListView = _cityService.All().CityListView,
        //    };*/

        //    return PartialView("_PeopleListPartial");
        //}

        //[HttpGet]
        //public IActionResult AllProducts()
        //{
        //    /*PeopleViewModel peopleViewModel = new PeopleViewModel()
        //    {
        //        PeopleListView = _peopleService.All().PeopleListView,
        //        CityListView = _cityService.All().CityListView,
        //    };*/

        //    return PartialView("ProductViewPartial");
        //}


        //[HttpPost]
        //public IActionResult FindPersonById(int id)
        //{
        //    /*PeopleViewModel peopleViewModel = new PeopleViewModel()
        //    {
        //        CityListView = _cityService.All().CityListView,
        //    };

        //    Person person = _peopleService.FindBy(id);

        //    if (person != null)
        //    {
        //        peopleViewModel.PeopleListView.Add(person);

        //        return PartialView("_PeopleListPartial", peopleViewModel);
        //    }
        //    */
        //    return StatusCode(404);

        //}

        //[HttpPost]
        //public IActionResult DeletePersonById(int id)
        //{
        //    /*bool success = _peopleService.Remove(id);

        //    if (success)
        //    {
        //        return StatusCode(200);
        //    }
        //    */
        //    return StatusCode(404);

        //}



    }
}
