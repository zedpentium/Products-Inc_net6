using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products_Inc.Models;
using Products_Inc.Models.ViewModels;

namespace Products_Inc.Models.Interfaces
{
    public interface IOrderRepo
    {
        Order Create(CreateOrderViewModel createOrderViewModel);


        //public bool AddLanguageToPerson(PersonLanguageViewModel personLanguageViewModel);


        List<Order> Read();
        List<Order> ReadByUser(string userid);


        Order Read(int id);


        Order Update(Order person);


        bool Delete(Order person);
        bool DeleteProduct(int productId);
        OrderProduct ReadOrderProduct(int productId);

        OrderProduct UpdateOrderProduct(int productId, OrderProduct order);
    }
}
