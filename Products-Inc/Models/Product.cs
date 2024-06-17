using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Products_Inc.Models
{
    public class Product
    {

        private string _productName;
        private string _productDescription;
        private int _productPrice;
        private string _imgPath;



        public Product() { }
        public Product(string productName, string productDescription = "", int productPrice = 0, string imgPath = "")
        {
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ImgPath = imgPath;
        }



        public int ProductId { get; set; }


        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public string ProductDescription
        {
            get { return _productDescription; }
            set { _productDescription = value; }
        }

        public int ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; }
        }

        public string ImgPath
        {
            get { return _imgPath; }
            set { _imgPath = value; }
        }

        public ICollection<Order> Orders { get; set; }

        public List<OrderProduct> OrderProducts { get; set; } // many-to-many link
    }


}
