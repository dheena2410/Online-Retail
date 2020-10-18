using System.Web.Http;
using RetailShop.BL.IService;
using RetailShop.BL.Models;
using System;

namespace RetailShop.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService OrderService)
        {
            _orderService = OrderService;
        }

        public IHttpActionResult Post(Order postObject)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid data.");
                }

                var result = _orderService.PlaceOrder(postObject);


                if (result == 0)
                {
                    return BadRequest("Unavailability of the product.");
                }

                return Ok("Record added successFully");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        public IHttpActionResult Delete(int OrderId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid data.");
                }

                var result = _orderService.CancelOrder(OrderId);


                if (result == 0)
                {
                    return BadRequest("No record deleted.");
                }

                return Ok("Record deletd successFully");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

    }
}
