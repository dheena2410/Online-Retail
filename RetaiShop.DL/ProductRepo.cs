using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using RetailShop.BL.Models;
using RetailShop.BL.IRepo;
using System.Data;
using System.Data.SqlClient;

namespace RetailShop.DL
{
    public class ProductRepo : IProductRepo
    {
        public readonly string Connection = ConfigurationManager.ConnectionStrings["RetailShopConnection"].ConnectionString;
        public List<Product> GetProduct()
        {
            try
            {
                string query = string.Empty;
                query = $"select ProductId,ProductCode,ProductName,Active from Product ";
                using (IDbConnection connection = new SqlConnection(Connection))
                {
                    return connection.Query<Product>(query).ToList();
                }
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
                string query = string.Empty;
                query = $"Insert into Product (ProductCode,ProductName,ProductQuantity) values (@ProductCode,@ProductName,@ProductQuantity) ";
                using (IDbConnection connection = new SqlConnection(Connection))
                {
                    var parameters = new
                    {
                        postObject.ProductCode,
                        postObject.ProductName,
                        postObject.ProductQuantity
                    };
                    var cmdDef = new CommandDefinition(query, parameters);
                    int result = connection.Execute(cmdDef);
                    return result;
                }
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
                string query = string.Empty;
                query = $"Update Product set ProductCode = @ProductCode,ProductName = @ProductName,ProductQuantity = @ProductQuantity where ProductId = @ProductId and Active = 1;  ";
                using (IDbConnection connection = new SqlConnection(Connection))
                {
                    var parameters = new
                    {
                        postObject.ProductCode,
                        postObject.ProductName,
                        postObject.ProductQuantity,
                        postObject.ProductId
                    };
                    var cmdDef = new CommandDefinition(query, parameters);
                    int result = connection.Execute(cmdDef);
                    return result;
                }
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
                    string query = string.Empty;
                    query = $"Update Product set Active = 0 where ProductId = @ProductId and Active = 1;  ";
                    using (IDbConnection connection = new SqlConnection(Connection))
                    {
                        var parameters = new
                        {
                            productId
                        };
                        var cmdDef = new CommandDefinition(query, parameters);
                        int result = connection.Execute(cmdDef);
                        return result;
                    }
                }
                catch (Exception exception)
                {
                Console.WriteLine(exception.Message);
                throw;
            }
            }
    }
}
