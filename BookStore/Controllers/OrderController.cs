using BusinessLayer.Interfaces;
using CommomLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        IOrderBL orderBL;

        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }

        [HttpPost]
        [Route("addOrders")]
        public IActionResult AddOrder([FromBody] OrderModel order)
        {
            try
            {
                string result = this.orderBL.AddOrder(order);
                if (result.Equals("Ordered successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetOrders")]
        public IActionResult RetrieveOrderDetails(int userId)
        {
            try
            {
                var result = this.orderBL.RetrieveOrderDetails(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrieved successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Retrieval unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

    }
}
