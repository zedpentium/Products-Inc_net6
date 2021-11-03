using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products_Inc.Models.ViewModels
{
    public class AddProductToShoppingCartViewModel
    {
        public ProductViewModel Product { get; set; }
        public ShoppingCartViewModel ShoppingCart { get; set; }
    }
}
