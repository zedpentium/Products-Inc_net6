using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products_Inc.Models;
using Products_Inc.Models.ViewModels;
using Products_Inc.Models.Interfaces;
using Products_Inc.Models.Exceptions;

namespace Products_Inc.Models.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;


        public OrderService(IOrderRepo iOrderRepo)
        {
            _orderRepo = iOrderRepo;
        }



        public OrderViewModel Create(CreateOrderViewModel createOrderViewModel)
        {
            Order createdOrder = _orderRepo.Create(createOrderViewModel);
            return GetModel(createdOrder);
        }



        public List<OrderViewModel> ReadAll()
        {
            return _orderRepo.Read().Select(o =>
             GetModel(o)).ToList();

        }

        public OrderViewModel Update(int id, Order order)
        {
            throw new NotImplementedException();
        }

        public OrderViewModel FindBy(int id)
        {
            Order foundOrder = _orderRepo.Read(id);

            return GetModel(foundOrder);
        }

        public bool Delete(int id)
        {
            Order orderToDelete = _orderRepo.Read(id);

            if (orderToDelete != null)
            {
                bool success = _orderRepo.Delete(orderToDelete);

                return success;
            }
            else
            {
                throw new EntityNotFoundException($"User with id ${id} not found");
            }

        }

        public List<OrderViewModel> FindAllBy(string userid)
        {
            return _orderRepo.ReadByUser(userid).Select(o => GetModel(o)).ToList();
        }

        public OrderViewModel GetModel(Order order)
        {
            //User user = _userManager.Users.FirstOrDefault(u => u.Id == order.UserId);
            //UserViewModel userViewModel = new UserViewModel() { Id = user.Id, UserName= user.UserName };


            return new OrderViewModel()
            {
                OrderId = order.OrderId,
               
                User = new UserViewModel() { Email = order.User.Email, UserName = order.User.UserName, Id = order.User.Id },
                UserId = order.UserId,
                
                OrderProducts = order.OrderProducts.Select(p =>
                    new OrderProductViewModel()
                    {
                        OrderProductId = p.OrderProductId,
                        ProductId = p.ProductId,
                        OrderId = p.OrderId,
                        Amount = p.Amount,
                        Product = new ProductViewModel()
                        {
                            ProductDescription = p.Product.ProductDescription,
                            ImgPath = p.Product.ImgPath,
                            ProductName = p.Product.ProductName,
                            ProductPrice = p.Product.ProductPrice
                        }
                    }).ToList()
            };
        }

        public bool DeleteProduct(int productId)
        {
            return _orderRepo.DeleteProduct(productId);
        }

        public OrderProductViewModel UpdateProduct(int productId, OrderProductViewModel orderProduct)
        {
            if(orderProduct.Amount > 0)
            {
                OrderProduct o = _orderRepo.UpdateOrderProduct(productId, new OrderProduct() { Amount = orderProduct.Amount });
                return new OrderProductViewModel() { Amount = o.Amount, OrderId = o.OrderId, OrderProductId = o.OrderProductId, Product = ProductService.GetModel(o.Product), ProductId = o.Product.ProductId };
            }
            else 
            {
                throw new Exception("Amount cannot be less than 0");
            }
        }
    }

}
