using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products_Inc.Models;
using Products_Inc.Models.Services;
using Products_Inc.Models.ViewModels;

namespace Products_Inc.Models.Interfaces
{
    public interface IShoppingCartService
    {
        ShoppingCartViewModel Create(CreateShoppingCartViewModel createShoppingCartViewModel);

        OrderViewModel CreateOrder(ShoppingCartViewModel shoppingViewModel);
        ShoppingCartViewModel Read(string id);
        List<ShoppingCartViewModel> ReadAll();
        ShoppingCartViewModel FindActiveBy(string userid);

        ShoppingCartViewModel FindBy(int id);

        ShoppingCartViewModel AddProduct(int productId, string shoppingCartId, int amount);
        ShoppingCartViewModel Update(int id, ShoppingCart shoppingCart);
        ShoppingCartViewModel UpdateProduct(ShoppingCartProductViewModel product, ShoppingCartViewModel shoppingCart);

        bool Delete(int id);

    }
}
