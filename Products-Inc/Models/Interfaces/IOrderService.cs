using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products_Inc.Models;
using Products_Inc.Models.Services;
using Products_Inc.Models.ViewModels;

namespace Products_Inc.Models.Interfaces
{
    public interface IOrderService
    {
        OrderViewModel Create(CreateOrderViewModel createOrderViewModel);

        List<OrderViewModel> ReadAll();
        List<OrderViewModel> FindAllBy(string username);

        //OrderViewModel FindBy(OrderViewModel search);
        
        OrderViewModel FindBy(int id);


        OrderViewModel Update(int id, Order order);

        bool Delete(int id);
        bool DeleteProduct(int productId);
        OrderProductViewModel UpdateProduct(int productId, OrderProductViewModel orderProduct);
    }
}
