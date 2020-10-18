using System.Collections.Generic;
using System.Web.Http;
using RetailShop.BL.IService;
using RetailShop.BL.Models;
using System;
using System.Threading.Tasks;

namespace RetailShop.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        public IHttpActionResult Get()
        {
            try
            {
                int id = 1;
                List<Product> productData = _productService.GetProduct(id);

                if (productData == null)
                {
                    return NotFound();
                }

                return Ok(productData);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        public IHttpActionResult Post(Product postObject)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid data.");
                }

                var result = _productService.AddProduct(postObject);


                if (result == 0)
                {
                    return BadRequest("No record added.");
                }

                return Ok("Record added successFully");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        public IHttpActionResult Put(Product postObject)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid data.");
                }

                var result = _productService.UpdateProduct(postObject);


                if (result == 0)
                {
                    return BadRequest("No record updated.");
                }

                return Ok("Record updated successFully");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }
        public async Task<IHttpActionResult> PutAsync(Product postObject)
        {
            return await Task.FromResult(Put(postObject));
        }
        public IHttpActionResult Delete(int productId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid data.");
                }

                var result = _productService.DeleteProduct(productId);


                if (result == 0)
                {
                    return BadRequest("No record deleted.");
                }

                return Ok("Record deleetd successFully");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }
        public async Task<IHttpActionResult> DeleteAsync(int productId)
        {
            return await Task.FromResult(Delete(productId));
        }

    }
}
