using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products_Inc.Models;
using Products_Inc.Models.ViewModels;

namespace Products_Inc.Models.Interfaces
{
    public interface IShoppingCartRepo
    {
        ShoppingCart Create(ShoppingCart shoppingCart);
        List<ShoppingCart> Read();
        ShoppingCart ReadActiveByUser(string userid);
        ShoppingCart Read(int id);
        ShoppingCart Update(ShoppingCart shoppingCart);
        ShoppingCart AddProduct(int productId, int shoppingCartId, int amount);
        bool Delete(ShoppingCart shoppingCart);
    }
}
