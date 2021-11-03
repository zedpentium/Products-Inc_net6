using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products_Inc.Models;
using Products_Inc.Models.ViewModels;

namespace Products_Inc.Models.Interfaces
{
    public interface IProductRepo
    {
        Product Create(CreateProductViewModel createProductViewModel);




        List<Product> Read();


        Product Read(int id);


        Product Update(int productId, Product product);


        bool Delete(Product product);
    }
}
