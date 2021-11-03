using System;
using System.Collections.Generic;
using Products_Inc.Models;


namespace Products_Inc.Models.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }


        public string UserId { get; set; } 

        public UserViewModel User { get; set; }
        public List<OrderProductViewModel> OrderProducts { get; set; }



    }
}
