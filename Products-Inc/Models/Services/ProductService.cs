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
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IImageService _imageService;

        public ProductService(IProductRepo iProductRepo, IImageService imageService)
        {
            _productRepo = iProductRepo;
            _imageService = imageService;
        }


        
        public ProductViewModel Create(CreateProductViewModel createProductViewModel)
        {
            if (!string.IsNullOrEmpty(createProductViewModel.ImgData))
            {
               createProductViewModel.ImgPath = _imageService.SaveImage(createProductViewModel.ImgData);
            }

            Product createdProduct = _productRepo.Create(createProductViewModel);
            return GetModel(createdProduct);
        }

        public List<ProductViewModel> ReadAll()
        {
            return _productRepo.Read().Select(p =>
            GetModel(p)).ToList();
        }

        //public List<Product> ReadAll()
        //{

        //    List<Product> productList = _productRepo.Read();
        //    Console.WriteLine(productList);
        //    return productList;
        //}

        public ProductViewModel Update(int id, CreateProductViewModel product)
        {
            if (!string.IsNullOrEmpty(product.ImgData))
            {
                product.ImgPath = _imageService.SaveImage(product.ImgData);
            }

            Product p = _productRepo.Update(id, GetProduct(product));
            return GetModel(p);
        }


        /*public ProductViewModel FindBy(ProductViewModel search)
        {
            search.ProductListView.Clear();

            List<Product> productList = _productRepo.Read();

            foreach (Product item in productList)
            {
                if (item.PersonName.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase) ||
                    item.City.CityName.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase)) 
                    // item.PersonLanguages.LanguageName.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase))
                {
                    search.PeopleListView.Add(item);
                }
            }

            if (search.PeopleListView.Count == 0)
            {
                search.SearchResultEmpty = $"No Person or City could be found, matching \"{search.FilterString}\" ";
            } else
            {
                search.SearchResultEmpty = "";
            }

            return search;

        }  */



        public ProductViewModel FindBy(int id)
        {
            Product foundProduct = _productRepo.Read(id);

            if (foundProduct != null)
                return GetModel(foundProduct);
            else
                throw new EntityNotFoundException("Product not found"); 
        }

        public bool Delete(int id)
        {
            Product productToDelete = _productRepo.Read(id);

            if(productToDelete != null)
            {
                bool success = _productRepo.Delete(productToDelete);
                return success;
            }
            else
            {
                throw new EntityNotFoundException("Product not found");
            }

 
        }

        public static ProductViewModel GetModel(Product product)
        {
            return new ProductViewModel() { 
                ImgPath = product.ImgPath, 
                ProductPrice = product.ProductPrice, 
                ProductDescription = product.ProductDescription, 
                ProductId = product.ProductId, 
                ProductName = product.ProductName 
            };

        }

        public static Product GetProduct(CreateProductViewModel product)
        {
            return new Product()
            {
                ImgPath = product.ImgPath,
                ProductPrice = product.ProductPrice,
                ProductDescription = product.ProductDescription,
                ProductName = product.ProductName
            };

        }

        /*public void CreateBaseProducts(List<ProductCity> cities)
        {
            _productRepo.Create("Eric Rönnhult", "0777 777777", cities[0]);
            _productRepo.Create("Bosse Bus", "0777 777777", cities[1]);
            _productRepo.Create("Kjell Kriminell", "0777 777777", cities[2]);
            _productRepo.Create("Anders Rolle", "0777 777777", cities[3]);

        }
        */

    }

}
