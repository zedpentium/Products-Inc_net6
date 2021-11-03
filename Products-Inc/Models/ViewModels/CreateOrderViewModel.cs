using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Products_Inc.Models.ViewModels
{
    public class CreateOrderViewModel
    {
   
        public string UserId { get; set; } 

        public List<OrderProductViewModel> Products { get; set; }

        public void AddProduct(OrderProductViewModel product)
        {
            if (Products == null)
                Products = new List<OrderProductViewModel>();

            Products.Add(product);
        }
    }  
     
}
