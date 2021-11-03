using System;
using System.Collections.Generic;
using Products_Inc.Models;

namespace Products_Inc.Models.ViewModels
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }


        public string ProductDescription { get; set; }


        public int ProductPrice { get; set; }


        public string ImgPath { get; set; }

        public int ProductId { get; set; }
    }
}
