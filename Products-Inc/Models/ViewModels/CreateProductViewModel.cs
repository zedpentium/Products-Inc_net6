using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Products_Inc.Models.ViewModels
{
    public class CreateProductViewModel
    {
        public string ProductName { get; set; }


        public string ProductDescription { get; set; }


        public int ProductPrice { get; set; }

        public string ImgPath { get; set; }
        public string ImgData { get; set; }



    }  
     
}
