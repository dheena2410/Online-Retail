using RetailShop.BL.IService;
using RetailShop.BL.IRepo;
using RetailShop.BL.Models;
using System.Collections.Generic;
using System;


namespace RetailShop.BL.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public List<Product> GetProduct(int id)
        {
            try
            {
                return _productRepo.GetProduct();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public int AddProduct(Product postObject)
        {
            try
            {
                return _productRepo.AddProduct(postObject);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public int UpdateProduct(Product postObject)
        {
            try
            {
                return _productRepo.UpdateProduct(postObject);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public int DeleteProduct(int productId)
        {
            try
            {
                return _productRepo.DeleteProduct(productId);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
    }
}
