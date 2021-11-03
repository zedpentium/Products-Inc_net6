using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products_Inc.Models;
using Products_Inc.Models.Services;
using Products_Inc.Models.ViewModels;

namespace Products_Inc.Models.Interfaces
{
    public interface IProductService
    {
        ProductViewModel Create(CreateProductViewModel product);

        List<ProductViewModel> ReadAll();

        //ProductViewModel FindBy(ProductViewModel search);

        ProductViewModel FindBy(int id);

        bool Delete(int id);
        ProductViewModel Update(int productId, CreateProductViewModel product);
    }
}
