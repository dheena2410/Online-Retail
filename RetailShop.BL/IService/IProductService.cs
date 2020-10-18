using System.Collections.Generic;
using RetailShop.BL.Models;

namespace RetailShop.BL.IService
{
    public interface IProductService
    {
        List<Product> GetProduct(int id);
        int AddProduct(Product postObject);
        int UpdateProduct(Product postObject);
        int DeleteProduct(int productId);
    }
}
