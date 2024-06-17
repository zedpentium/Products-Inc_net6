using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products_Inc.Models;
using Products_Inc.Models.Interfaces;
using Products_Inc.Models.ViewModels;
using Products_Inc.Models.Exceptions;

namespace Products_Inc.Data
{
    public class DbOrderRepo : IOrderRepo
    {
        private readonly ApplicationDbContext _orderRepo;

        public DbOrderRepo(ApplicationDbContext orderRepo)
        {
            _orderRepo = orderRepo;

        }


        public Order Create(CreateOrderViewModel createOrderViewModel)
        {
            Order newOrder = new Order() {
            UserId = createOrderViewModel.UserId,
            OrderProducts = createOrderViewModel.Products.Select(op => 
            new OrderProduct() { ProductId =  op.Product.ProductId, 
                Amount = op.Amount}).ToList() 
            };

            _orderRepo.Orders.Add(newOrder);
            _orderRepo.SaveChanges();

            return Read(newOrder.OrderId);
        }


        public List<Order> Read()
        {
            List<Order> pList = _orderRepo.Orders
                .Include(f => f.OrderProducts).ThenInclude(g => g.Product)
                .Include(o => o.User)
                .ToList();

            return pList;
        }

        public Order Read(int id)
        {
            Order order = _orderRepo.Orders
                .Where(c => c.OrderId == id)
                .Include(f => f.OrderProducts).ThenInclude(g => g.Product)
                .Include(o => o.User)
                .FirstOrDefault();

            return order;
        }

        public List<Order> ReadByUser(string userId)
        {
            return _orderRepo.Orders.Include(o => o.OrderProducts).ThenInclude(op => op.Product).Where(o => o.UserId.Equals(userId)).ToList();
        }

        public Order Update(Order order)
        {
            _orderRepo.Orders.Update(order);
            _orderRepo.SaveChanges();

            return order;
        }

        public bool Delete(Order order)
        {
            int nrStates;

            _orderRepo.Orders.Remove(order);
            nrStates = _orderRepo.SaveChanges();

            if (nrStates > 0)
            {
                return true;
            }

            return false;


        }

        public bool DeleteProduct(int productId)
        {
            OrderProduct orderProduct = ReadOrderProduct(productId);

            _orderRepo.OrderProducts.Remove(orderProduct);
            _orderRepo.SaveChanges();
            return true;
    
        }

        public OrderProduct ReadOrderProduct(int productId)
        {
            OrderProduct orderProduct = _orderRepo.OrderProducts.Include(op => op.Product).Where(op => op.OrderProductId == productId).FirstOrDefault();
            if (orderProduct != null)
            {
                return orderProduct;
            }
            else
                throw new EntityNotFoundException("Orderproduct with id " + productId + " not found.");
        }

        public OrderProduct UpdateOrderProduct(int productId, OrderProduct orderProduct)
        {
            OrderProduct originalOrderProduct = ReadOrderProduct(productId);

            originalOrderProduct.Amount = orderProduct.Amount;

            _orderRepo.OrderProducts.Update(originalOrderProduct);
            _orderRepo.SaveChanges();

            return ReadOrderProduct(productId);
        }
    }
}
