using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Products_Inc.Models.ViewModels
{
    public class ShoppingCartProductViewModel
    {
        public int ShoppingCartId { get; set; }
        public ProductViewModel Product { get; set; }

        [Required]
        public int ProductId { get; set; }

        public int Amount { get; set; }
    }
}
