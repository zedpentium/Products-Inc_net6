using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace Products_Inc.Models
{
    public class Order
    {

        public Order() { }
        public Order(string userId)
        {
            UserId = userId; 
        }
        public Order(string userId, List<OrderProduct> orderProducts)
        {
            UserId = userId;
            OrderProducts = orderProducts;
        }


        public int OrderId { get; set; }

        public string UserId { get; set; } // This is Identity UserID named Id as a string in identity table


        public User User { get; set; }
        

        public List<OrderProduct> OrderProducts { get; set; } // dotnet core 3.1 many-to-many link
    }
}
