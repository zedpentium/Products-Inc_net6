using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Products_Inc.Models
{
    public class ShoppingCart 
    {
        [Key]
        public int ShoppingCartId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public List<ShoppingCartProduct> Products { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }
        public bool TransactionComplete { get; set; }

        public void AddProduct(ShoppingCartProduct product)
        {
            if (Products == null)
                Products = new List<ShoppingCartProduct>();

            Products.Add(product);
        }
    }
}
