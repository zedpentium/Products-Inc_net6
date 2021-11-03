using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products_Inc.Models;
using Products_Inc.Models.Interfaces;
using Products_Inc.Models.ViewModels;

namespace Products_Inc.Data
{
    public class DbProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _productListContext;

        public DbProductRepo(ApplicationDbContext productListContext)
        {
            _productListContext = productListContext;

        }


        public Product Create(CreateProductViewModel createProductViewModel)
            
        {
            Product createProduct = new Product(createProductViewModel.ProductName, createProductViewModel.ProductDescription,
            createProductViewModel.ProductPrice, createProductViewModel.ImgPath);

            _productListContext.Products.Add(createProduct);
            _productListContext.SaveChanges();

            return createProduct;
        }

        public List<Product> Read()
        {
            List<Product> pList = _productListContext.Products.ToList();

            return pList;
        }

        public Product Read(int id)
        {
            Product person = _productListContext.Products
                .Where(c => c.ProductId == id)
                .FirstOrDefault();

            return person;
        }

        public Product Update(int productId, Product product)
        {
            Product original = Read(productId);

            if (!string.IsNullOrEmpty(product.ProductDescription))
            {
                original.ProductDescription = product.ProductDescription;
            }
            if (!string.IsNullOrEmpty(product.ProductName))
            {
                original.ProductName = product.ProductName;
            }
            if (product.ProductPrice > 0)
            {
                original.ProductPrice = product.ProductPrice;
            }
            if (!string.IsNullOrEmpty(product.ImgPath)){
                original.ImgPath = product.ImgPath;
            }
            
            _productListContext.Products.Update(original);
            _productListContext.SaveChanges();

            return Read(productId);
        }

        public bool Delete(Product person)
        {
            int nrStates;

            _productListContext.Products.Remove(person);
            nrStates = _productListContext.SaveChanges();

            if (nrStates > 0)
            {
                return true;
            }

            return false;


        }

    }
}
