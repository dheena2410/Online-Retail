using System.Collections.Generic;
using RetailShop.BL.Models;

namespace RetailShop.BL.IRepo
{
    public interface IProductRepo
    {
        List<Product> GetProduct();
        int AddProduct(Product postObject);
        int UpdateProduct(Product postObject);
        int DeleteProduct(int productId);
    }
}
